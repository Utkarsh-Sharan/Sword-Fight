using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    private EnemyType _enemyType;
    private Dictionary<EnemyType, EnemyScriptableObject> enemySODictionary = new Dictionary<EnemyType, EnemyScriptableObject>();
    protected EnemyView enemyView;

    protected Transform playerTransform;
    protected PlayerScriptableObject playerSO;

    private bool _isPlayerDead;
    public bool IsPlayerInDetectionZone { get; set; }

    public EnemyController(EnemyScriptableObject enemySO)
    {
        _isPlayerDead = false;

        enemySODictionary[enemySO.EnemyType] = enemySO;
        _enemyType = enemySO.EnemyType;

        EventService.Instance.OnPlayerDeathEvent.AddListener(OnPlayerDead);
    }

    public void InjectDependency(PlayerService playerService)
    {
        playerTransform = playerService.GetPlayerTransform();
        playerSO = playerService.GetPlayerSO();
    }

    private void OnPlayerDead() => _isPlayerDead = true;

    #region Getters
    public Animator GetEnemyAnimator() => enemyView.GetEnemyAnimator();
    public NavMeshAgent GetEnemyAgent() => enemyView.GetEnemyAgent();
    public List<Transform> GetWayPointTransformList() => enemyView.GetWayPointTransformList();
    public EnemyScriptableObject GetEnemySO(EnemyType enemyType) => enemySODictionary[enemyType];
    public EnemyType GetEnemyType() => _enemyType;
    public Transform GetPlayerTransform() => playerTransform;
    public Transform GetEnemyTransform() => enemyView.transform;
    public bool IsPlayerDead() => _isPlayerDead;
    #endregion

    public void RemoveListeners()
    {
        EventService.Instance.OnPlayerDeathEvent.RemoveListener(OnPlayerDead);
    }
}
