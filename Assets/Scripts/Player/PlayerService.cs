using UnityEngine;

public class PlayerService
{
    private PlayerController _playerController;

    public PlayerService(PlayerController playerController, CharacterController characterController, Animator playerAnimator, DamageApplier damageApplier, PlayerScriptableObject playerSO)
    {
        _playerController = playerController;
        playerController.Init(characterController, playerAnimator, damageApplier, playerSO);
    }

    public void Dependency(EnemyService enemyService) => _playerController.Dependency(enemyService);

    public Transform GetPlayerTransform() => _playerController.GetPlayerTransform();

    public PlayerScriptableObject GetPlayerSO() => _playerController.GetPlayerSO();
}
