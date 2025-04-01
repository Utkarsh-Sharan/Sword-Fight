using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService
{
    private List<SpawnDataAndWaypoints> _spawnDataAndWaypoints;
    private Dictionary<EnemyType, EnemyScriptableObject> _enemySODictionary;

    private EnemyController _enemyController;

    public EnemyService(List<EnemyScriptableObject> enemySOList)
    {
        _spawnDataAndWaypoints = new List<SpawnDataAndWaypoints>();
        _spawnDataAndWaypoints = EventService.Instance.OnSpawnDataInitialized.InvokeEvent();

        _enemySODictionary = new Dictionary<EnemyType, EnemyScriptableObject>();
        foreach (EnemyScriptableObject enemySO in enemySOList)
            _enemySODictionary[enemySO.EnemyType] = enemySO;

        CreateEnemyControllers(_spawnDataAndWaypoints);
    }

    private void CreateEnemyControllers(List<SpawnDataAndWaypoints> spawnDataAndWaypoints)
    {
        for(int i = 0; i < spawnDataAndWaypoints.Count; ++i)
        {
            switch (spawnDataAndWaypoints[i].EnemyType)
            {
                case EnemyType.Tank:
                    CreateTankEnemy(spawnDataAndWaypoints[i].SpawnPosition, spawnDataAndWaypoints[i].Waypoints);
                    break;

                default:
                    Debug.LogError("No enemy of this type exists!");
                    break;
            }
        }

        PlayerService playerService = EventService.Instance.OnPlayerServiceInitialized.InvokeEvent();
        _enemyController.InjectDependency(playerService);
    }

    private void CreateTankEnemy(Vector3 spawnPosition, List<Vector3> waypointsList)
    {
        _enemyController = new TankEnemyController(_enemySODictionary[EnemyType.Tank], spawnPosition, waypointsList);
    }

    public EnemyType GetEnemyType() => _enemyController.GetEnemyType();
    public EnemyScriptableObject GetEnemySO(EnemyType enemyType) => _enemyController.GetEnemySO(enemyType);
}
