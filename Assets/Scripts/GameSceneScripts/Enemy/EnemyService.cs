using System.Collections.Generic;
using UnityEngine;

public class EnemyService
{
    private EnemyController _enemyController;
    private List<SpawnDataAndWaypoints> _spawnDataAndWaypoints;
    private Dictionary<EnemyType, EnemyScriptableObject> _enemySODictionary;

    public EnemyService(EnemyController enemyController, List<EnemyScriptableObject> enemySOList)
    {
        _enemyController = enemyController;

        _spawnDataAndWaypoints = new List<SpawnDataAndWaypoints>();
        _enemySODictionary = new Dictionary<EnemyType, EnemyScriptableObject>();

        _spawnDataAndWaypoints = EventService.Instance.OnSpawnDataInitialized.InvokeEvent();

        foreach (EnemyScriptableObject enemySO in enemySOList)
            _enemySODictionary[enemySO.EnemyType] = enemySO;

        CreateEnemyControllers(_spawnDataAndWaypoints);
    }

    private void CreateEnemyControllers(List<SpawnDataAndWaypoints> spawnDataAndWaypoints)
    {
        for(int i = 0; i < spawnDataAndWaypoints.Count; ++i)
        {
            if(spawnDataAndWaypoints[i].EnemyType == EnemyType.Tank)
                CreateTankEnemy(spawnDataAndWaypoints[i].SpawnPosition, spawnDataAndWaypoints[i].Waypoints);
        }
    }

    private void CreateTankEnemy(Vector3 spawnPosition, List<Vector3> waypointsList)
    {
        TankEnemyController tankEnemyController = new TankEnemyController(_enemySODictionary[EnemyType.Tank], spawnPosition, waypointsList);
    }

    public void InjectDependency(PlayerService playerService) => _enemyController.InjectDependency(playerService);

    public EnemyType GetEnemyType() => _enemyController.GetEnemyType();
    public EnemyScriptableObject GetEnemySO(EnemyType enemyType) => _enemyController.GetEnemySO(enemyType);
}
