using TMPro;
using UnityEngine;

public abstract class ResourceUI : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TMP_Text _maxCount;
    [SerializeField] private TMP_Text _count;
    [SerializeField] private RectTransform _visionPositiom;
    [SerializeField] private RectTransform _notVisionPositiom;

    private const string IncreaseText = "Increase";

    public string Name { get; protected set; }

    public void ChangePosition(bool value)
    {
        if (value == true)
            transform.position = _notVisionPositiom.position;
        else
            transform.position = _visionPositiom.position;
    }

    public void PlayAnimationIncrease()
    {
        _animator.SetTrigger(IncreaseText);
    }

    public void SetCurrentCount(int count, bool isPlayAnimation)
    {
        if (isPlayAnimation == true)
            _animator.SetTrigger(IncreaseText);

        _count.text = count.ToString();
    }

    public void SetMaxCount(int count)
    {
        _maxCount.text = count.ToString();
    }
}
