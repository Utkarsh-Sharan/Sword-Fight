using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected List<Transform> waypointTransformList;
    [SerializeField] protected BoxCollider playerDetectionCollider;

    protected NavMeshAgent enemyAgent;
    protected Animator enemyAnimator;
    protected EnemyStateMachine _stateMachine;
    protected Transform playerTransform;

    public virtual void Initialize(NavMeshAgent enemyAgent, Animator enemyAnimator)
    {
        this.enemyAgent = enemyAgent;
        this.enemyAnimator = enemyAnimator;

        _stateMachine = new EnemyStateMachine(this);
        _stateMachine.ChangeState(States.Idle);
    }

    public void Dependency(PlayerService playerService)
    {
        playerTransform = playerService.GetPlayerTransform();
    }

    protected void Update()
    {
        _stateMachine.Update();
    }

    public Animator GetEnemyAnimator() => enemyAnimator;
    public NavMeshAgent GetEnemyAgent() => enemyAgent;
    public List<Transform> GetWayPointTransformList() => waypointTransformList;
}
