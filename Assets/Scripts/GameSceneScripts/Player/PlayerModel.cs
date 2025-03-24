using UnityEngine;

public class PlayerModel
{
    private int _currentHealth;
    public int CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }
    private float _moveSpeed;
    private float _gravity;

    private float _turnSmoothTime;

    public PlayerModel(PlayerScriptableObject playerSO)
    {
        _currentHealth = playerSO.MaxHealth;
        _moveSpeed = playerSO.MoveSpeed;
        _gravity = playerSO.Gravity;
        _turnSmoothTime = playerSO.TurnSmoothTime;
    }

    public float GetMoveSpeed() => _moveSpeed;
    public float GetGravity() => _gravity;
    public float GetTurnSmoothTime() => _turnSmoothTime;
}
