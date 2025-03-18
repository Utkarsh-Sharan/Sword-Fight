using System.Collections.Generic;
using UnityEditor.MPE;
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

    public void Dependency(PlayerService playerService, EventService eventService) => _enemyController.Dependency(playerService, eventService);

    public EnemyType GetEnemyType() => _enemyController.GetEnemyType();
    public EnemyScriptableObject GetEnemySO(EnemyType enemyType) => _enemyController.GetEnemySO(enemyType);
}
