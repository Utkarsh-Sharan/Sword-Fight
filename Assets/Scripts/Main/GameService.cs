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

    [Header("Enemy Properties")]
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private NavMeshAgent _enemyAgent;
    [SerializeField] private Animator _enemyAnimator;

    [Header("VFX Properties")]
    [SerializeField] private EnemyView _enemyVFXController;
    [SerializeField] private PlayerView _playerVFXController;
    [SerializeField] private List<VFXScriptableObject> _vFXSOList;

    private PlayerService _playerService;
    private EnemyService _enemyService;
    private VFXService _vFXService;

    private void Start()
    {
        CreateServices();
        InjectDependencies();
    }

    private void CreateServices()
    {
        _playerService = new PlayerService(_playerController, _characterController, _playerAnimator);
        _enemyService = new EnemyService(_enemyController, _enemyAgent, _enemyAnimator);
    }

    private void InjectDependencies()
    {
        _enemyService.Dependency(_playerService);
    }
}
