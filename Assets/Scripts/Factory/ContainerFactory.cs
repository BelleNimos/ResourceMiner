using UnityEngine;

public class ContainerFactory : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private Resource _prefabContainerResource;
    [SerializeField] private FactoryAnimator _factoryAnimator;

    private Resource _sampleResource;

    public string NameResource => _sampleResource.Name;

    private void Awake()
    {
        _factoryAnimator = GetComponent<FactoryAnimator>();
    }

    private void Start()
    {
        _sampleResource = Instantiate(_prefabContainerResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
    }

    public void DestroyResource(Resource resource)
    {
        _factoryAnimator.PlayVibrationAnimation();
        Destroy(resource.gameObject);
    }
}
