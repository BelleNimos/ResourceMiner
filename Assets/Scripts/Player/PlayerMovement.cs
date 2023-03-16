using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(PlayerAnimator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private Bag _bag;

    private NavMeshAgent _navMeshAgent;
    private float _moveSpeed;
    private float _rotateSpeed;

    public float MoveSpeed => _moveSpeed;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _rotateSpeed = 1f;
        _moveSpeed = _gameSettings.MoveSpeed;
    }

    public void Move(Vector3 moveDirection)
    {
        moveDirection = moveDirection.normalized * _moveSpeed;
        _navMeshAgent.Move(moveDirection * Time.deltaTime);
    }

    public void Rotate(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
