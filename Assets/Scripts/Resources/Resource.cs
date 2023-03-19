using DG.Tweening;
using UnityEngine;

public abstract class Resource : MonoBehaviour
{
    [SerializeField] protected ResourceSettings ResourceSettings;

    private bool _isReady;
    private float _delayAfterFill;
    private float _afterFillTimer = 0f;

    private const float DurationAnimation = 0.5f;
    private const int ResourceLayer = 6;
    private const int ResourceDropLayer = 7;

    public int NumJumps { get; } = 1;
    public float Duration { get; protected set; }
    public float JumpPower { get; protected set; }
    public string Name { get; protected set; }

    private void Start()
    {
        _isReady = false;
        _delayAfterFill = ResourceSettings.DelayAfterFall;
    }

    private void Update()
    {
        if (_isReady == true)
            _afterFillTimer += Time.deltaTime;
    }

    public bool CheckReadiness()
    {
        if (_afterFillTimer >= _delayAfterFill)
        {
            _isReady = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeLayer()
    {
        if (gameObject.layer == ResourceLayer)
            gameObject.layer = ResourceDropLayer;
        else
            gameObject.layer = ResourceLayer;
    }

    public void PlayDecreaseAnimation()
    {
        transform.DOScale(new Vector3(0, 0, 0), DurationAnimation);
    }

    public void PlayIncreaseAnimation()
    {
        transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), DurationAnimation);
    }

    public void EnableTimer()
    {
        _isReady = true;
    }
}
