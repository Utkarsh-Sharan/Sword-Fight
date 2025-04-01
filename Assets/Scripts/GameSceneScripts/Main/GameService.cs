using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    [Header("Level Properties")]
    [SerializeField] private LevelController _levelController;

    [Header("UI Service")]
    [SerializeField] private UIService _uIService;

    [Header("Scriptable Objects")]
    [SerializeField] private LevelScriptableObject _levelSO;
    [SerializeField] private EnemySpawnDataScriptableObject _enemySpawnDataSO;
    [SerializeField] private List<EnemyScriptableObject> _enemySOList;
    [SerializeField] private PlayerScriptableObject _playerSO;

    private LevelService _levelService;
    private SpawnService _spawnService;
    private PlayerService _playerService;
    private EnemyService _enemyService;

    private void Start()
    {
        CreateServices();
        InjectDependencies();
    }

    private void CreateServices()
    {
        _levelService = new LevelService(_levelController, _levelSO);
        _spawnService = new SpawnService(_enemySpawnDataSO);
        _playerService = new PlayerService(_playerSO);
        _enemyService = new EnemyService(_enemySOList, _playerService);
    }

    private void InjectDependencies()
    {
        _playerService.Dependency(_enemyService);
    }
}
