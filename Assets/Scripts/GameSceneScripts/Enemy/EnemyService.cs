using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyService
{
    private EnemyController _enemyController;
    private Dictionary<EnemyType, EnemyScriptableObject> enemySODictionary;

    public EnemyService(EnemyController enemyController, NavMeshAgent enemyAgent, Animator enemyAnimator, List<EnemyScriptableObject> enemySOList)
    {
        enemySODictionary = new Dictionary<EnemyType, EnemyScriptableObject>();

        foreach (EnemyScriptableObject enemySO in enemySOList)
            enemySODictionary[enemySO.EnemyType] = enemySO;

        CreateEnemyControllers();

        _enemyController = enemyController;
        _enemyController.Initialize(enemyAgent, enemyAnimator, enemySOList);
    }

    private void CreateEnemyControllers()
    {
        TankEnemyController tankEnemyController = new TankEnemyController(enemySODictionary[EnemyType.Tank]);
    }

    public void Dependency(PlayerService playerService) => _enemyController.Dependency(playerService);

    public EnemyType GetEnemyType() => _enemyController.GetEnemyType();
    public EnemyScriptableObject GetEnemySO(EnemyType enemyType) => _enemyController.GetEnemySO(enemyType);
}
