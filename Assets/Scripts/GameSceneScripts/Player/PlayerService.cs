using UnityEngine;

public class PlayerService
{
    private PlayerController _playerController;

    public PlayerService(PlayerScriptableObject playerSO)
    {
        _playerController = new PlayerController(playerSO);
    }

    public void Dependency(EnemyService enemyService) => _playerController.Dependency(enemyService);

    public Transform GetPlayerTransform() => _playerController.GetPlayerTransform();
    public PlayerScriptableObject GetPlayerSO() => _playerController.GetPlayerSO();
    private PlayerService GetPlayerService() => this;
}
