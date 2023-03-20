using DG.Tweening;
using UnityEngine;

public class FactoryAnimator : MonoBehaviour
{
    private Vector3 _startPosition;

    private const float _delay = 0.05f;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    public void PlayVibrationAnimation()
    {
        Vector3 onePosition = new(_startPosition.x + 0.1f, _startPosition.y + 0.1f, _startPosition.z + 0.1f);
        Vector3 twoPosition = new(_startPosition.x - 0.1f, _startPosition.y - 0.1f, _startPosition.z - 0.1f);
        Vector3 threePosition = new(_startPosition.x + 0.1f, _startPosition.y + 0.1f, _startPosition.z - 0.1f);
        Vector3 fourPosition = new(_startPosition.x - 0.1f, _startPosition.y - 0.1f, _startPosition.z + 0.1f);

        DOTween.Sequence()
            .Append(transform.DOMove(onePosition, _delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(_startPosition, _delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(twoPosition, _delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(_startPosition, _delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(threePosition, _delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(_startPosition, _delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(fourPosition, _delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject)
            .Append(transform.DOMove(_startPosition, _delay)).SetUpdate(UpdateType.Normal, false).SetLink(gameObject);
    }
}
