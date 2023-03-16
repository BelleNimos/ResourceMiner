using UnityEngine;

[RequireComponent(typeof(FactoryAnimator), typeof(SpawnerFactory), typeof(ContainerFactory))]
public class Factory : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;

    private SpawnerFactory _spawnerResources;
    private ContainerFactory _containerResources;

    private void Awake()
    {
        _spawnerResources = GetComponent<SpawnerFactory>();
        _containerResources = GetComponent<ContainerFactory>();
    }

    public void TransferResource(Resource resource)
    {
        _containerResources.DestroyResource(resource);
    }

    public void TakeResource(Bag bag)
    {
        if (bag.CheckAvailabilityResource(_containerResources.NameResource) == true)
        {
            bag.GiveAwayResource(this, _containerResources.NameResource);
            _spawnerResources.Invoke("InstantiateResource", 5f);
        }
    }
}
