using UnityEngine;

public class PlayerService
{
    private PlayerController _playerController;

    public PlayerService(PlayerController playerController, CharacterController characterController, Animator playerAnimator, PlayerScriptableObject playerSO)
    {
        _playerController = playerController;
        playerController.Init(characterController, playerAnimator, playerSO);
    }

    public void Dependency(EnemyService enemyService, EventService eventService) => _playerController.Dependency(enemyService, eventService);

    public Transform GetPlayerTransform() => _playerController.GetPlayerTransform();

    public PlayerScriptableObject GetPlayerSO() => _playerController.GetPlayerSO();
}
