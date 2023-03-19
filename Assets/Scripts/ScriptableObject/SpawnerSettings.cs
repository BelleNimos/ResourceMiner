using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings/SpawnerSettings", order = 51)]
public class SpawnerSettings : ScriptableObject
{
    [Header("CountResources")]
    [SerializeField] private int _countCrystal;
    [SerializeField] private int _countGold;
    [SerializeField] private int _countIron;
    [SerializeField] private int _countCoal;
    [SerializeField] private int _countLumber;

    [Header("CountPerHit")]
    [SerializeField] private int _countPerHitCrystal;
    [SerializeField] private int _countPerHitGold;
    [SerializeField] private int _countPerHitIron;
    [SerializeField] private int _countPerHitCoal;
    [SerializeField] private int _countPerHitLumber;

    [Header("DelayBeforeRecovery")]
    [SerializeField] private float _delayBeforeRecoveryCrystal;
    [SerializeField] private float _delayBeforeRecoveryGold;
    [SerializeField] private float _delayBeforeRecoveryIron;
    [SerializeField] private float _delayBeforeRecoveryCoal;
    [SerializeField] private float _delayBeforeRecoveryLumber;

    [Header("ProductionRate")]
    [SerializeField] private float _productionRateCrystal;
    [SerializeField] private float _productionRateGold;
    [SerializeField] private float _productionRateIron;
    [SerializeField] private float _productionRateCoal;
    [SerializeField] private float _productionRateLumber;

    public int CountCrystal => _countCrystal;
    public int CountGold => _countGold;
    public int CountIron => _countIron;
    public int CountCoal => _countCoal;
    public int CountLumber => _countLumber;

    public int CountPerHitCrystal => _countPerHitCrystal;
    public int CountPerHitGold => _countPerHitGold;
    public int CountPerHitIron => _countPerHitIron;
    public int CountPerHitCoal => _countPerHitCoal;
    public int CountPerHitLumber => _countPerHitLumber;

    public float DelayBeforeRecoveryCrystal => _delayBeforeRecoveryCrystal;
    public float DelayBeforeRecoveryGold => _delayBeforeRecoveryGold;
    public float DelayBeforeRecoveryIron => _delayBeforeRecoveryIron;
    public float DelayBeforeRecoveryCoal => _delayBeforeRecoveryCoal;
    public float DelayBeforeRecoveryLumber => _delayBeforeRecoveryLumber;

    public float ProductionRateCrystal => _productionRateCrystal;
    public float ProductionRateGold => _productionRateGold;
    public float ProductionRateIron => _productionRateIron;
    public float ProductionRateCoal => _productionRateCoal;
    public float ProductionRateLumber => _productionRateLumber;
}
