using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings/BagSettings", order = 51)]
public class BagSettings : ScriptableObject
{
    [Header("Options")]
    [SerializeField] private float _resourceSpread;
    [SerializeField] private float _delayFlyingResource;

    [Header("CountResources")]
    [SerializeField] private int _maxCountCrystal;
    [SerializeField] private int _maxCountGold;
    [SerializeField] private int _maxCountIron;
    [SerializeField] private int _maxCountCoal;
    [SerializeField] private int _maxCountLumber;

    public float ResourceSpread => _resourceSpread;
    public float DelayFlyingResource => _delayFlyingResource;

    public int MaxCountCrystal => _maxCountCrystal;
    public int MaxCountGold => _maxCountGold;
    public int MaxCountIron => _maxCountIron;
    public int MaxCountCoal => _maxCountCoal;
    public int MaxCountLumber => _maxCountLumber;
}
