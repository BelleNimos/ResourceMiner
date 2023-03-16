using UnityEngine;

public class JoystickMovement : JoystickHandler
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAnimator _playerAnimator;

    public bool IsActive { get; private set; }

    private void Update()
    {
        if (InputVector.x != 0 || InputVector.y != 0)
        {
            _playerAnimator.PlayRunAnimation();
            _playerMovement.Move(new Vector3(InputVector.x, 0, InputVector.y));
            _playerMovement.Rotate(new Vector3(InputVector.x, 0, InputVector.y));
            IsActive = true;
        }
        else
        {
            _playerAnimator.PlayIdleAnimation();
            IsActive = false;
        }
    }
}
