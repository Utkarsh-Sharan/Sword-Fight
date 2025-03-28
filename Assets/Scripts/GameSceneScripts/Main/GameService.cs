using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameService : MonoBehaviour
{
    [Header("Player properties")]
    [SerializeField] private PlayerScriptableObject _playerSO;

    [Header("Enemy Properties")]
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private List<EnemyScriptableObject> _enemySOList;

    [Header("Level Properties")]
    [SerializeField] private LevelController _levelController;
    [SerializeField] private List<LevelScriptableObject> _levelSOList;

    [Header("UI Service")]
    [SerializeField] private UIService _uIService;

    private LevelService _levelService;
    private PlayerService _playerService;
    private EnemyService _enemyService;

    private void Start()
    {
        CreateServices();
        InjectDependencies();
    }

    private void CreateServices()
    {
        _levelService = new LevelService(_levelController, _levelSOList);
        _playerService = new PlayerService(_playerSO);
        _enemyService = new EnemyService(_enemyController, _enemySOList);
    }

    private void InjectDependencies()
    {
        _enemyService.Dependency(_playerService);
        _playerService.Dependency(_enemyService);
    }
}
