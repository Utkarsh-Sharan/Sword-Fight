using System.Collections.Generic;

public class SpawnService
{
    private LevelNumber _currentLevel;
    private List<SpawnDataAndWaypoints> _spawnDataAndWaypoints;

    public SpawnService(EnemySpawnDataScriptableObject enemySpawnDataSO)
    {
        EventService.Instance.OnSpawnDataInitialized.AddListener(OnSpawnDataInitialized);

        _currentLevel = EventService.Instance.OnCurrentLevelSelectedEvent.InvokeEvent();

        foreach (LevelSpawnData levelData in enemySpawnDataSO.LevelSpawnData)
        {
            if (levelData.LevelNumber == _currentLevel)
            {
                _spawnDataAndWaypoints = levelData.SpawnDataAndWaypoints;
                break;
            }
        }
    }

    private List<SpawnDataAndWaypoints> OnSpawnDataInitialized() => _spawnDataAndWaypoints;

    ~SpawnService()
    {
        EventService.Instance.OnSpawnDataInitialized.RemoveListener(OnSpawnDataInitialized);
    }
}
