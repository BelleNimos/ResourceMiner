using DG.Tweening;
using UnityEngine;

public class FactoryAnimator : MonoBehaviour
{
    private Vector3 _startPosition;

    private void Awake()
    {
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
}
