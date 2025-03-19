using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class GameService : MonoBehaviour
{
    [Header("Player properties")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private PlayerScriptableObject _playerSO;

    [Header("Enemy Properties")]
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private NavMeshAgent _enemyAgent;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private List<EnemyScriptableObject> _enemySOList;

    [Header("Level Properties")]
    [SerializeField] private LevelController _levelController;
    [SerializeField] private List<LevelScriptableObject> _levelSOList;

    [Header("UI Service")]
    [SerializeField] private UIService _uIService;

    private LevelService _levelService;
    private PlayerService _playerService;
    private EnemyService _enemyService;
    private EventService _eventService;

    private void Start()
    {
        CreateServices();
        InjectDependencies();
    }

    private void CreateServices()
    {
        _eventService = new EventService();
        _levelService = new LevelService(_levelController, _levelSOList);
        _playerService = new PlayerService(_playerController, _characterController, _playerAnimator, _playerSO);
        _enemyService = new EnemyService(_enemyController, _enemyAgent, _enemyAnimator, _enemySOList);
    }

    private void InjectDependencies()
    {
        _levelService.Dependency(_eventService);
        _enemyService.Dependency(_playerService, _eventService);
        _playerService.Dependency(_enemyService, _eventService);
        _uIService.Dependency(_eventService);
    }
}
