using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private Bag _bag;
    [SerializeField] private JoystickMovement _joystickMovement;

    private PlayerAnimator _playerAnimator;
    private float _productionRate;
    private float _productionRateTimer = 0f;

    private void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _productionRate = _gameSettings.ProductionRate;
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
                if (spawner.CurrentCountResource > 0 && _productionRateTimer >= _productionRate)
                    ExtractResource(spawner);

        if (other.TryGetComponent<Factory>(out Factory factory))
            if (_joystickMovement.IsActive == false)
                if (_productionRateTimer >= _productionRate)
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
        spawner.ThrowAwayResource();
        ResetTimer();
    }
}
