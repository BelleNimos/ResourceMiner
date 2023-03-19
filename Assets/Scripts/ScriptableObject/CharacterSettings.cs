using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings/CharacterSettings", order = 51)]
public class CharacterSettings : ScriptableObject
{
    [Header("Options")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _radiusPickUpResource;

    public float MoveSpeed => _moveSpeed;
    public float RadiusPickUpResource => _radiusPickUpResource;
}
