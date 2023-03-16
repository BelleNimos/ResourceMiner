using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFactory : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private Resource _prefabSpawnResource;
    [SerializeField] private List<Point> _spawnPoints;
    [SerializeField] private FactoryAnimator _factoryAnimator;
    [SerializeField] private int _countGiveResources;

    private Stack<Resource> _resources;

    private const int NumJumps = 1;
    private const float JumpPower = 8f;
    private const float Duration = 0.6f;

    public int CountResources => _resources.Count;

    private void Awake()
    {
        _resources = new Stack<Resource>();
    }

    private void ThrowAwayResource()
    {
        _factoryAnimator.PlayVibrationAnimation();

        int index = Random.Range(0, _spawnPoints.Count);

        Resource resource = _resources.Pop();

        resource.transform.DOJump(_spawnPoints[index].transform.position, JumpPower, NumJumps, Duration)
            .SetUpdate(UpdateType.Normal, false)
            .SetLink(resource.gameObject)
            .OnKill(() =>
            {
                resource.ChangeLayer();
                resource.EnableTimer();
            });
    }

    public void InstantiateResource()
    {
        for (int i = 0; i < _countGiveResources; i++)
        {
            _resources.Push(Instantiate(_prefabSpawnResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity));
            ThrowAwayResource();
        }
    }
}
