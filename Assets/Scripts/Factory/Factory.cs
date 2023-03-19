using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FactoryAnimator))]
public abstract class Factory : MonoBehaviour
{
    [SerializeField] protected List<Point> SpawnPoints;
    [SerializeField] protected FactorySettings FactorySettings;
    [SerializeField] protected Resource PrefabSpawnResource;
    [SerializeField] protected Resource PrefabContainerResource;

    private Stack<Resource> _resources;
    private FactoryAnimator _factoryAnimator;
    private int _counter = 0;

    protected Resource SampleResource;
    protected int CountResourcesRequired;
    protected int CountResourceTakes;

    public float ProductionRate { get; private set; }
    public string NameResource => SampleResource.Name;
    public int CountResources => _resources.Count;

    private void Awake()
    {
        _resources = new Stack<Resource>();
        _factoryAnimator = GetComponent<FactoryAnimator>();
    }

    private void Start()
    {
        ProductionRate = FactorySettings.ProductionRate;
    }

    private void ThrowAwayResource()
    {
        int index = Random.Range(0, SpawnPoints.Count);

        Resource resource = _resources.Pop();

        resource.transform.DOJump(SpawnPoints[index].transform.position, resource.JumpPower, resource.NumJumps, resource.Duration)
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
        _factoryAnimator.PlayVibrationAnimation();

        for (int i = 0; i < CountResourcesRequired; i++)
        {
            _resources.Push(Instantiate(PrefabSpawnResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity));
            ThrowAwayResource();
        }

        _counter = 0;
    }

    public void TakeResource(Bag bag)
    {
        if (bag.CheckAvailabilityResource(NameResource) == true)
            bag.GiveAwayResource(this, NameResource);
    }

    public void DestroyResource(Resource resource)
    {
        Destroy(resource.gameObject);

        _counter++;

        if (_counter == CountResourceTakes)
            InstantiateResource();
    }
}
