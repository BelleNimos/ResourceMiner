using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string RunText = "Run";
    private const string IdleText = "Idle";
    private const string MiningText = "Mining";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRunAnimation()
    {
        _animator.SetBool(RunText, true);
        _animator.SetBool(IdleText, false);
    }

    public void PlayIdleAnimation()
    {
        _animator.SetBool(IdleText, true);
        _animator.SetBool(RunText, false);
    }

    public void PlayMiningAnimation()
    {
        _animator.SetTrigger(MiningText);
    }
}
