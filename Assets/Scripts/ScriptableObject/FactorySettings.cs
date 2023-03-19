using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings/FactorySettings", order = 51)]
public class FactorySettings : ScriptableObject
{
    [Header("ProductionRate")]
    [SerializeField] private float _productionRate;

    [Header("CountResourcesRequired")]
    [SerializeField] private int _countResourcesRequiredFactoryCoalInLumber;
    [SerializeField] private int _countResourcesRequiredFactoryCrystalInGold;
    [SerializeField] private int _countResourcesRequiredFactoryCrystalInIron;
    [SerializeField] private int _countResourcesRequiredFactoryGoldInCrystal;
    [SerializeField] private int _countResourcesRequiredFactoryGoldInIron;
    [SerializeField] private int _countResourcesRequiredFactoryIronInCrystal;
    [SerializeField] private int _countResourcesRequiredFactoryIronInGold;
    [SerializeField] private int _countResourcesRequiredFactoryLumberInCoal;

    [Header("CountResourcesTakes")]
    [SerializeField] private int _countResourcesTakesFactoryCoalInLumber;
    [SerializeField] private int _countResourcesTakesFactoryCrystalInGold;
    [SerializeField] private int _countResourcesTakesFactoryCrystalInIron;
    [SerializeField] private int _countResourcesTakesFactoryGoldInCrystal;
    [SerializeField] private int _countResourcesTakesFactoryGoldInIron;
    [SerializeField] private int _countResourcesTakesFactoryIronInCrystal;
    [SerializeField] private int _countResourcesTakesFactoryIronInGold;
    [SerializeField] private int _countResourcesTakesFactoryLumberInCoal;

    public float ProductionRate => _productionRate;

    public int CountResourcesRequiredFactoryCoalInLumber => _countResourcesRequiredFactoryCoalInLumber;
    public int CountResourcesRequiredFactoryCrystalInGold => _countResourcesRequiredFactoryCrystalInGold;
    public int CountResourcesRequiredFactoryCrystalInIron => _countResourcesRequiredFactoryCrystalInIron;
    public int CountResourcesRequiredFactoryGoldInCrystal => _countResourcesRequiredFactoryGoldInCrystal;
    public int CountResourcesRequiredFactoryGoldInIron => _countResourcesRequiredFactoryGoldInIron;
    public int CountResourcesRequiredFactoryIronInCrystal => _countResourcesRequiredFactoryIronInCrystal;
    public int CountResourcesRequiredFactoryIronInGold => _countResourcesRequiredFactoryIronInGold;
    public int CountResourcesRequiredFactoryLumberInCoal => _countResourcesRequiredFactoryLumberInCoal;

    public int CountResourcesTakesFactoryCoalInLumber => _countResourcesTakesFactoryCoalInLumber;
    public int CountResourcesTakesFactoryCrystalInGold => _countResourcesTakesFactoryCrystalInGold;
    public int CountResourcesTakesFactoryCrystalInIron => _countResourcesTakesFactoryCrystalInIron;
    public int CountResourcesTakesFactoryGoldInCrystal => _countResourcesTakesFactoryGoldInCrystal;
    public int CountResourcesTakesFactoryGoldInIron => _countResourcesTakesFactoryGoldInIron;
    public int CountResourcesTakesFactoryIronInCrystal => _countResourcesTakesFactoryIronInCrystal;
    public int CountResourcesTakesFactoryIronInGold => _countResourcesTakesFactoryIronInGold;
    public int CountResourcesTakesFactoryLumberInCoal => _countResourcesTakesFactoryLumberInCoal;
}
