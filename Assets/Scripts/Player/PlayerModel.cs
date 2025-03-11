using UnityEngine;

public class PlayerModel
{
    private float _moveSpeed = 5f;
    private float _gravity = -20f;
    private float _verticalVelocity;
    private Vector3 _movementVelocity;

    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;

    private float _attackStartTime;
    private float _attackSlideDuration = 0.5f;
    private float _attackSlideSpeed = 0.09f;
    private bool _isAttacking;

    public Vector3 CalculateMovement(Transform playerTransform, float horizontalInput, float verticalInput, bool isGrounded)
    {
        if (_isAttacking)
        {
            if (Time.time < _attackStartTime + _attackSlideDuration)
            {
                _movementVelocity = Vector3.zero;
                float timePassed = Time.time - _attackStartTime;
                float lerpTime = timePassed / _attackSlideDuration;

                _movementVelocity = Vector3.Lerp(playerTransform.forward * _attackSlideSpeed, Vector3.zero, lerpTime);

                _isAttacking = false;
                return _movementVelocity;
            }
        }

        _movementVelocity.Set(horizontalInput, 0, verticalInput);
        _movementVelocity.Normalize();
        _movementVelocity *= _moveSpeed * Time.deltaTime;

        _verticalVelocity = isGrounded ? _gravity * 0.3f : _gravity;
        _movementVelocity += _verticalVelocity * Vector3.up * Time.deltaTime;

        return _movementVelocity;
    }

    public Quaternion CalculateRotation(Vector3 direction, float currentYRotation)
    {
        if(direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(currentYRotation, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            return Quaternion.Euler(0, angle, 0);
        }

        return Quaternion.Euler(0, currentYRotation, 0);
    }

    public void AttackSlideForward()
    {
        _attackStartTime = Time.time;
        _isAttacking = true;
    }
}
