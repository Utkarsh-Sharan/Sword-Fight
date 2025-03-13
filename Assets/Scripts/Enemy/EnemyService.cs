using UnityEngine;
using UnityEngine.AI;

public class EnemyService
{
    private EnemyController _enemyController;

    public EnemyService(EnemyController enemyController, NavMeshAgent enemyAgent, Animator enemyAnimator)
    {
        _enemyController = enemyController;
        _enemyController.Initialize(enemyAgent, enemyAnimator);
    }

    public void Dependency(PlayerService playerService)
    {
        _enemyController.Dependency(playerService);
    }
}
