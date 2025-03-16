using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected List<Transform> waypointTransformList;

    protected NavMeshAgent enemyAgent;
    protected Animator enemyAnimator;
    protected Transform playerTransform;

    public bool IsPlayerInDetectionZone { get; set; }

    public virtual void Initialize(NavMeshAgent enemyAgent, Animator enemyAnimator)
    {
        this.enemyAgent = enemyAgent;
        this.enemyAnimator = enemyAnimator;
    }

    public void Dependency(PlayerService playerService)
    {
        playerTransform = playerService.GetPlayerTransform();
    }

    public Animator GetEnemyAnimator() => enemyAnimator;
    public NavMeshAgent GetEnemyAgent() => enemyAgent;
    public List<Transform> GetWayPointTransformList() => waypointTransformList;
    public Transform GetPlayerTransform() => playerTransform;
}
