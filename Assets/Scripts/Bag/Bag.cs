using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class Bag : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private List<Point> _departurePoints;
    [SerializeField] private List<ResourceUI> _resourcesUI;

    private Animator _animator;
    private List<string> _keys;
    private Dictionary<string, Cell> _cells;

    private const string Fill = "Fill";
    private const int NumJumps = 1;
    private const float JumpPower = 2f;
    private const float Duration = 0.25f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _keys = new List<string>() { "Crystal", "Iron", "Lumber", "Gold", "Coal" };
        _cells = new Dictionary<string, Cell>();
    }

    private void Start()
    {
        foreach (var key in _keys)
            _cells.Add(key, new Cell(10));

        foreach (var cell in _cells)
            foreach (var resourceUI in _resourcesUI)
                if (cell.Key == resourceUI.Name)
                    cell.Value.SetResourceUI(resourceUI);

        foreach (var cell in _cells)
            cell.Value.AssignCount();
    }

    private void MoveResource(Transform target, Resource resource)
    {
        resource.transform.DOJump(target.position, JumpPower, NumJumps, Duration)
            .SetUpdate(UpdateType.Normal, false)
            .SetLink(resource.gameObject)
            .OnKill(() =>
            {
                resource.transform.SetParent(target, true);
                resource.transform.localPosition = new Vector3(0, 0, 0);
                resource.transform.localRotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
            }
            );
    }

    private Point GetRandomPoint()
    {
        int index = Random.Range(0, _departurePoints.Count);

        return _departurePoints[index];
    }

    public void AddResource(Resource resource)
    {
        foreach (var cell in _cells)
        {
            if (cell.Key == resource.Name)
            {
                if (_cells[resource.Name].MaxCountResources > cell.Value.CurrentCountResources)
                {
                    MoveResource(transform, resource);
                    resource.ChangeLayer();
                    resource.PlayDecreaseAnimation();
                    _animator.SetTrigger(Fill);
                    cell.Value.AddResource(resource);
                }
            }
        }
    }

    public bool CheckAvailabilityResource(string name)
    {
        foreach (var cell in _cells)
            if (cell.Key == name)
                if (cell.Value.CurrentCountResources > 0)
                    return true;

        return false;
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

                    resource.transform.DOJump(GetRandomPoint().transform.position, JumpPower, NumJumps, Duration)
                        .SetUpdate(UpdateType.Normal, false)
                        .SetLink(resource.gameObject)
                        .OnKill(() =>
                        {
                            resource.transform.DOJump(factory.transform.position, JumpPower, NumJumps, Duration)
                                .SetUpdate(UpdateType.Normal, false)
                                .SetLink(resource.gameObject)
                                .OnKill(() =>
                                {
                                    resource.transform.SetParent(factory.transform, true);
                                    resource.transform.localPosition = new Vector3(0, 0, 0);
                                    resource.transform.localRotation = Quaternion.LookRotation(new Vector3(0, 0, 0));
                                    factory.TransferResource(resource);
                                }
                                );
                        }
                        );
                }
            }
        }
    }
}
