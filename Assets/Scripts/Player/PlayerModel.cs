using System;
using UnityEngine;

public class PlayerModel
{
    private int _currentHealth;
    private float _moveSpeed;
    private float _gravity;
    private float _verticalVelocity;
    private Vector3 _movementVelocity;

    private float _turnSmoothTime;
    private float _turnSmoothVelocity;

    public PlayerModel(PlayerScriptableObject playerSO)
    {
        _currentHealth = playerSO.MaxHealth;
        _moveSpeed = playerSO.MoveSpeed;
        _gravity = playerSO.Gravity;
        _turnSmoothTime = playerSO.TurnSmoothTime;
    }

    public Vector3 CalculateMovement(Transform playerTransform, float horizontalInput, float verticalInput, bool isGrounded)
    {
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

    public void OnDamage(int damageAmount)
    {
        if (_currentHealth > 0)
            _currentHealth -= damageAmount;
        else
            PlayerDead();
    }

    private void PlayerDead()
    {
        Debug.Log("Player dead");
    }
}
