using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected List<Transform> waypointTransformList;
    [SerializeField] protected BoxCollider playerDetectionCollider;

    protected NavMeshAgent enemyAgent;
    protected Animator enemyAnimator;
    protected Transform playerTransform;

    public bool IsPlayerInRange { get; set; }

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
    public Vector3 GetPlayerPosition() => playerTransform.position;
}
