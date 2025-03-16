using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankEnemyController : EnemyController
{
    private TankEnemyStateMachine _stateMachine;

    public override void Initialize(NavMeshAgent enemyAgent, Animator enemyAnimator, List<EnemyScriptableObject> enemySOList)
    {
        base.Initialize(enemyAgent, enemyAnimator, enemySOList);

        this.enemyAgent.speed = GetEnemySO(EnemyType.Tank).MoveSpeed;

        _stateMachine = new TankEnemyStateMachine(this);
        _stateMachine.ChangeState(States.Idle);
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}
