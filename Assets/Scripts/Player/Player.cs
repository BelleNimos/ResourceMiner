using UnityEngine;

[RequireComponent(typeof(PlayerAnimator), typeof(BoxCollider))]
public class Player : MonoBehaviour
{
    [SerializeField] private CharacterSettings _characterSettings;
    [SerializeField] private Bag _bag;
    [SerializeField] private JoystickMovement _joystickMovement;

    private PlayerAnimator _playerAnimator;
    private BoxCollider _boxCollider;
    private float _productionRateTimer = 0f;

    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        _boxCollider.size = new Vector3(_characterSettings.RadiusPickUpResource, 2, _characterSettings.RadiusPickUpResource);
    }

    private void Update()
    {
        _productionRateTimer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Resource>(out Resource resource))
            if (resource.CheckReadiness() == true)
                _bag.AddResource(resource);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Spawner>(out Spawner spawner))
            if (_joystickMovement.IsActive == false)
                if (spawner.CurrentCountResource > 0 && _productionRateTimer >= spawner.ProductionRate)
                    ExtractResource(spawner);

        if (other.TryGetComponent<Factory>(out Factory factory))
            if (_joystickMovement.IsActive == false)
                if (_productionRateTimer >= factory.ProductionRate)
                    GiveAwayResource(factory);
    }

    private void ResetTimer()
    {
        _productionRateTimer = 0f;
    }

    private void GiveAwayResource(Factory factory)
    {
        factory.TakeResource(_bag);
        ResetTimer();
    }

    private void ExtractResource(Spawner spawner)
    {
        _playerAnimator.PlayMiningAnimation();
        spawner.ThrowAwayResources();
        ResetTimer();
    }
}
