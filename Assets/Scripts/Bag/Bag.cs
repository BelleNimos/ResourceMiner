using System.IO;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class Bag : MonoBehaviour
{
    [SerializeField] private BagSettings _bagSettings;
    [SerializeField] private List<Cell> _listCells;
    [SerializeField] private List<ResourceUI> _resourcesUI;
    [SerializeField] private List<Point> _departurePoints;
    [SerializeField] private Transform _points;

    private BagData _bagData;
    private Animator _animator;
    private Dictionary<string, Cell> _cells;
    private float _delayFlyingResource;
    private string _savePath;
    private string _saveFileName = "bagData.json";

    private const string FillText = "Fill";

    private void Awake()
    {
        _delayFlyingResource = _bagSettings.DelayFlyingResource;
        _points.localScale = new Vector3(_bagSettings.ResourceSpread, 1, _bagSettings.ResourceSpread);

        _cells = new Dictionary<string, Cell>();
        _bagData = new BagData();
        _animator = GetComponent<Animator>();

        for (int i = 0; i < _listCells.Count; i++)
            _cells.Add(_listCells[i].Name, _listCells[i]);

#if UNITY_ANDROID && !UNITY_EDITOR
        _savePath = Path.Combine(Application.persistentDataPath, saveFileName);
#else
        _savePath = Path.Combine(Application.dataPath, _saveFileName);
#endif
        if (File.Exists(_savePath) == true)
            _bagData.LoadFromFile(_savePath, _cells, transform);
        else
            SetCellsMaxCount();
    }

    private void Start()
    {
        foreach (var cell in _cells)
            cell.Value.AssignCount();
    }

    private void OnApplicationQuit()
    {
        _bagData.SaveToFile(_savePath, _cells);
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (Application.platform == RuntimePlatform.Android)
            _bagData.SaveToFile(_savePath, _cells);
    }

    private Point GetRandomPoint()
    {
        int index = Random.Range(0, _departurePoints.Count);

        return _departurePoints[index];
    }

    private void SetCellsMaxCount()
    {
        foreach (var cell in _cells)
        {
            if (cell.Key == "Crystal")
                cell.Value.SetMaxCountResources(_bagSettings.MaxCountCrystal);
            else if (cell.Key == "Gold")
                cell.Value.SetMaxCountResources(_bagSettings.MaxCountGold);
            else if (cell.Key == "Iron")
                cell.Value.SetMaxCountResources(_bagSettings.MaxCountIron);
            else if (cell.Key == "Coal")
                cell.Value.SetMaxCountResources(_bagSettings.MaxCountCoal);
            else if (cell.Key == "Lumber")
                cell.Value.SetMaxCountResources(_bagSettings.MaxCountLumber);
        }
    }

    private void MoveResource(Resource resource)
    {
        resource.transform.DOJump(transform.position, resource.JumpPower, resource.NumJumps, resource.Duration)
            .SetUpdate(UpdateType.Normal, false)
            .SetLink(resource.gameObject)
            .OnKill(() =>
            {
                resource.transform.SetParent(transform, true);
                resource.transform.localPosition = new Vector3(0, 0, 0);
                resource.transform.localRotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
            }
            );
    }

    public bool CheckAvailabilityResource(string name)
    {
        foreach (var cell in _cells)
            if (cell.Key == name)
                if (cell.Value.CurrentCountResources > 0)
                    return true;

        return false;
    }

    public void AddResource(Resource resource)
    {
        foreach (var cell in _cells)
        {
            if (cell.Key == resource.Name)
            {
                if (cell.Value.MaxCountResources > cell.Value.CurrentCountResources)
                {
                    MoveResource(resource);
                    resource.ChangeLayer();
                    resource.PlayDecreaseAnimation();
                    _animator.SetTrigger(FillText);
                    cell.Value.AddResource(resource);
                }
            }
        }
    }

    public void GiveAwayResource(Factory factory, string nameResource)
    {
        foreach (var cell in _cells)
        {
            if (cell.Key == nameResource)
            {
                if (cell.Value.CurrentCountResources > 0)
                {
                    Resource resource = null;

                    cell.Value.PullResource(ref resource);

                    resource.PlayIncreaseAnimation();
                    resource.transform.SetParent(null, true);

                    resource.transform.DOJump(GetRandomPoint().transform.position, resource.JumpPower, resource.NumJumps, resource.Duration)
                        .SetUpdate(UpdateType.Normal, false)
                        .SetLink(resource.gameObject)
                        .AppendInterval(_delayFlyingResource)
                        .OnKill(() =>
                        {
                            resource.transform.DOJump(factory.transform.position, resource.JumpPower, resource.NumJumps, resource.Duration)
                                .SetUpdate(UpdateType.Normal, false)
                                .SetLink(resource.gameObject)
                                .OnKill(() =>
                                {
                                    resource.transform.localPosition = new Vector3(0, 0, 0);
                                    resource.transform.localRotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
                                    factory.DestroyResource(resource);
                                }
                                );
                        }
                        );
                }
            }
        }
    }
}
