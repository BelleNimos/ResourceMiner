using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string Run = "Run";
    private const string Idle = "Idle";
    private const string Mining = "Mining";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRunAnimation()
    {
        _animator.SetBool(Run, true);
        _animator.SetBool(Idle, false);
    }

    public void PlayIdleAnimation()
    {
        _animator.SetBool(Idle, true);
        _animator.SetBool(Run, false);
    }

    public void PlayMiningAnimation()
    {
        _animator.SetTrigger(Mining);
    }
}
