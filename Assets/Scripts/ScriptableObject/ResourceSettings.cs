using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings/ResourceSettings", order = 51)]
public class ResourceSettings : ScriptableObject
{
    [Header("Options")]
    [SerializeField] private float _delayAfterFall;

    [Header("JumpPower")]
    [SerializeField] private float _jumpPowerCrystal;
    [SerializeField] private float _jumpPowerGold;
    [SerializeField] private float _jumpPowerIron;
    [SerializeField] private float _jumpPowerCoal;
    [SerializeField] private float _jumpPowerLumber;

    [Header("DurationJump")]
    [SerializeField] private float _durationJumpCrystal;
    [SerializeField] private float _durationJumpGold;
    [SerializeField] private float _durationJumpIron;
    [SerializeField] private float _durationJumpCoal;
    [SerializeField] private float _durationJumpLumber;

    public float DelayAfterFall => _delayAfterFall;

    public float JumpPowerCrystal => _jumpPowerCrystal;
    public float JumpPowerGold => _jumpPowerGold;
    public float JumpPowerIron => _jumpPowerIron;
    public float JumpPowerCoal => _jumpPowerCoal;
    public float JumpPowerLumber => _jumpPowerLumber;

    public float DurationJumpCrystal => _durationJumpCrystal;
    public float DurationJumpGold => _durationJumpGold;
    public float DurationJumpIron => _durationJumpIron;
    public float DurationJumpCoal => _durationJumpCoal;
    public float DurationJumpLumber => _durationJumpLumber;
}
