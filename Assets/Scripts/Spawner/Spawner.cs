using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpawnerAnimator))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private List<Point> _spawnPoints;
    [SerializeField] private Resource _prefabResource;

    private Stack<Resource> _resources;
    private SpawnerAnimator _spawnerAnimator;
    private int _maxResourcesCount = 5;
    private float _spawnTimer = 0f;
    private float _delaySpawn = 5f;
    private bool _isEmpty;
    
    private const int NumJumps = 1;
    private const float JumpPower = 8f;
    private const float Duration = 0.6f;

    public int CurrentCountResource => _resources.Count;

    private void Awake()
    {
        _resources = new Stack<Resource>();
        _spawnerAnimator = GetComponent<SpawnerAnimator>();
    }

    private void Start()
    {
        InstantiateResources();
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_isEmpty == true && _spawnTimer >= _delaySpawn)
        {
            InstantiateResources();
            _spawnerAnimator.PlayAnimationIncrease();
        }
    }

    private void ResetTimerSpawn()
    {
        _spawnerAnimator.PlayAnimationDecrease();
        _spawnTimer = 0f;
        _isEmpty = true;
    }

    public void InstantiateResources()
    {
        for (int i = 0; i < _maxResourcesCount; i++)
            _resources.Push(Instantiate(_prefabResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity));

        _isEmpty = false;
    }

    public void ThrowAwayResource()
    {
        _spawnerAnimator.PlayVibrationAnimation();

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

        if (_resources.Count == 0)
            ResetTimerSpawn();
    }
}
