using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Resource : MonoBehaviour
{
    [SerializeField] GameSettings _gameSettings;

    private Animator _animator;
    private bool _isReady;
    private float _delayAfterFall;
    private float _afterFallTimer = 0f;
    
    private const int ResourceLayer = 6;
    private const int ResourceDropLayer = 7;
    
    private const string Decrease = "Decrease";
    private const string Increase = "Increase";

    public string Name { get; protected set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _isReady = false;
        _delayAfterFall = _gameSettings.DelayAfterFall;
    }

    private void Update()
    {
        if (_isReady == true)
            _afterFallTimer += Time.deltaTime;
    }

    public bool CheckReadiness()
    {
        if (_afterFallTimer >= _delayAfterFall)
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
        _animator.SetTrigger(Decrease);
    }

    public void PlayIncreaseAnimation()
    {
        _animator.SetTrigger(Increase);
    }

    public void EnableTimer()
    {
        _isReady = true;
    }
}
