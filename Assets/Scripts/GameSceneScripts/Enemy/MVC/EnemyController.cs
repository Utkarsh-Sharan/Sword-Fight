using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    private EnemyType _enemyType;
    private Dictionary<EnemyType, EnemyScriptableObject> enemySODictionary = new Dictionary<EnemyType, EnemyScriptableObject>();
    protected EnemyView enemyView;

    private bool _isPlayerDead;
    public bool IsPlayerInDetectionZone { get { return enemyView.IsPlayerInDetectionZone; } set { enemyView.IsPlayerInDetectionZone = value; } }

    public EnemyController(EnemyScriptableObject enemySO)
    {
        _isPlayerDead = false;

        enemySODictionary[enemySO.EnemyType] = enemySO;
        _enemyType = enemySO.EnemyType;

        EventService.Instance.OnPlayerDeathEvent.AddListener(OnPlayerDead);
    }

    private void OnPlayerDead() => _isPlayerDead = true;

    #region Getters
    public Animator GetEnemyAnimator() => enemyView.GetEnemyAnimator();
    public NavMeshAgent GetEnemyAgent() => enemyView.GetEnemyAgent();
    public List<Vector3> GetWaypointsList() => enemyView.GetWaypointsList();
    public EnemyScriptableObject GetEnemySO(EnemyType enemyType) => enemySODictionary[enemyType];
    public EnemyType GetEnemyType() => _enemyType;
    public Transform GetEnemyTransform() => enemyView.transform;
    public bool IsPlayerDead() => _isPlayerDead;
    #endregion

    public void RemoveListeners()
    {
        EventService.Instance.OnPlayerDeathEvent.RemoveListener(OnPlayerDead);
    }
}
