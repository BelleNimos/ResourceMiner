using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings/GameSettings", order = 51)]
public class GameSettings : ScriptableObject
{
    [Header("Player")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _productionRate;

    [Header("Resource")]
    [SerializeField] private float _delayAfterFall;

    public float MoveSpeed => _moveSpeed;
    public float ProductionRate => _productionRate;
    public float DelayAfterFall => _delayAfterFall;
}
