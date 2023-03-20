using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PointerIcon _pointerIcon;

    private Camera _camera;
    private Plane[] _planes;
    private Vector3 _playerToPoint;
    private Vector3 _worldPosition;
    private Ray _ray;
    private float _minDistance;

    public bool IsEnable { get; private set; }

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        _playerToPoint = transform.position - _player.transform.position;
        _ray = new Ray(_player.transform.position, _playerToPoint);
        _planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        _minDistance = Mathf.Infinity;
        int planeIndex = 0;

        for (int i = 0; i < 4; i++)
        {
            if (_planes[i].Raycast(_ray, out float distance) == true)
            {
                if (distance < _minDistance)
                {
                    _minDistance = distance;
                    planeIndex = i;
                }
            }
        }

        _minDistance = Mathf.Clamp(_minDistance, 0, _playerToPoint.magnitude);
        _worldPosition = _ray.GetPoint(_minDistance);

        Vector3 position = _camera.WorldToScreenPoint(_worldPosition);
        Vector3 nextPosition = new(position.x, position.y + 150f, position.z);
        Quaternion rotation;

        if (_playerToPoint.magnitude > _minDistance)
        {
            rotation = GetIconRotation(planeIndex);
            _pointerIcon.SetIconPosition(position, rotation);
        }
        else
        {
            rotation = GetIconRotation(2);
            _pointerIcon.SetIconPosition(nextPosition, rotation);
        }
    }

    private Quaternion GetIconRotation(int index)
    {
        if (index == 0)
            return Quaternion.Euler(0f, 0f, -90f);
        else if (index == 1)
            return Quaternion.Euler(0f, 0f, 90f);
        else if (index == 2)
            return Quaternion.Euler(0f, 0f, 0f);
        else if (index == 3)
            return Quaternion.Euler(0f, 0f, 180f);

        return Quaternion.identity;
    }

    public void Enable()
    {
        _pointerIcon.gameObject.SetActive(true);
        IsEnable = true;
    }

    public void Disable()
    {
        _pointerIcon.gameObject.SetActive(false);
        IsEnable = false;
    }
}
