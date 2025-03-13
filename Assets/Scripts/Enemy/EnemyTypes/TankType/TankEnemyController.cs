using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankEnemyController : EnemyController
{
    private float _moveSpeed = 2.3f;
    private TankEnemyStateMachine _stateMachine;
    public bool IsPlayerInRange { get; set; }

    public override void Initialize(NavMeshAgent enemyAgent, Animator enemyAnimator)
    {
        base.Initialize(enemyAgent, enemyAnimator);
        playerDetectionCollider.GetComponent<PlayerDetectionCollider>().Initialize(this);

        this.enemyAgent.speed = _moveSpeed;
        _stateMachine = new TankEnemyStateMachine(this);
        _stateMachine.ChangeState(States.Idle);
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}
