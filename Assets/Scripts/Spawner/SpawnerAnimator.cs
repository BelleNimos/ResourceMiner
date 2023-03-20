using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SpawnerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Vector3 _startPosition;

    private const string DecreaseText = "Decrease";
    private const string IncreaseText = "Increase";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _startPosition = transform.position;
    }

    public void PlayVibrationAnimation()
    {
        float delay = 0.05f;
        Vector3 onePosition = new Vector3(_startPosition.x + 0.1f, _startPosition.y + 0.1f, _startPosition.z + 0.1f);
        Vector3 twoPosition = new Vector3(_startPosition.x - 0.1f, _startPosition.y - 0.1f, _startPosition.z - 0.1f);
        Vector3 threePosition = new Vector3(_startPosition.x + 0.1f, _startPosition.y + 0.1f, _startPosition.z - 0.1f);
        Vector3 fourPosition = new Vector3(_startPosition.x - 0.1f, _startPosition.y - 0.1f, _startPosition.z + 0.1f);

        DOTween.Sequence()
            .Append(transform.DOMove(onePosition, delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(_startPosition, delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(twoPosition, delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(_startPosition, delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(threePosition, delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(_startPosition, delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(fourPosition, delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(_startPosition, delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject);
    }

    public void PlayAnimationIncrease()
    {
        _animator.SetTrigger(IncreaseText);
    }

    public void PlayAnimationDecrease()
    {
        _animator.SetTrigger(DecreaseText);
    }
}
