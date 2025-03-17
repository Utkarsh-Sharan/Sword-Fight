using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected EnemyType enemyType;
    [SerializeField] protected List<Transform> waypointTransformList;

    protected Dictionary<EnemyType, EnemyScriptableObject> enemySODictionary;
    protected NavMeshAgent enemyAgent;
    protected Animator enemyAnimator;
    protected Transform playerTransform;

    public bool IsPlayerInDetectionZone { get; set; }

    public virtual void Initialize(NavMeshAgent enemyAgent, Animator enemyAnimator, List<EnemyScriptableObject> enemySOList)
    {
        this.enemyAgent = enemyAgent;
        this.enemyAnimator = enemyAnimator;

        enemySODictionary = new Dictionary<EnemyType, EnemyScriptableObject>();
        foreach (EnemyScriptableObject enemySO in enemySOList)
            enemySODictionary[enemySO.EnemyType] = enemySO;
    }

    public void Dependency(PlayerService playerService)
    {
        playerTransform = playerService.GetPlayerTransform();
    }

    public Animator GetEnemyAnimator() => enemyAnimator;
    public NavMeshAgent GetEnemyAgent() => enemyAgent;
    public List<Transform> GetWayPointTransformList() => waypointTransformList;
    public EnemyScriptableObject GetEnemySO(EnemyType enemyType) => enemySODictionary[enemyType];
    public EnemyType GetEnemyType() => enemyType;
    public Transform GetPlayerTransform() => playerTransform;
}
