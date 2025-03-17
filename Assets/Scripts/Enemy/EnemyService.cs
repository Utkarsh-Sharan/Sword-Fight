using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyService
{
    private EnemyController _enemyController;

    public EnemyService(EnemyController enemyController, NavMeshAgent enemyAgent, Animator enemyAnimator, List<EnemyScriptableObject> enemySOList)
    {
        _enemyController = enemyController;
        _enemyController.Initialize(enemyAgent, enemyAnimator, enemySOList);
    }

    public void Dependency(PlayerService playerService) => _enemyController.Dependency(playerService);

    public EnemyScriptableObject GetEnemySO() => _enemyController.GetEnemySO(_enemyController.GetEnemyType());
}
