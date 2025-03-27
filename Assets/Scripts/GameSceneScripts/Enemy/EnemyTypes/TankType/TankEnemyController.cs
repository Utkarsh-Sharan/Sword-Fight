using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankEnemyController : EnemyController
{
    private TankEnemyModel _tankEnemyModel;
    private TankEnemyView _tankEnemyView;
    private TankEnemyStateMachine _stateMachine;

    public TankEnemyController(EnemyScriptableObject tankEnemySO) : base()
    {
        _tankEnemyModel = new TankEnemyModel(tankEnemySO);
        _tankEnemyView = (TankEnemyView)Object.Instantiate(tankEnemySO.EnemyView);
        _tankEnemyView.Initialize(this);
        
        _stateMachine = new TankEnemyStateMachine(this);
        _stateMachine.ChangeState(States.Idle);
    }

    public override void Initialize(NavMeshAgent enemyAgent, Animator enemyAnimator, List<EnemyScriptableObject> enemySOList)
    {
        base.Initialize(enemyAgent, enemyAnimator, enemySOList);

        //this.enemyAgent.speed = GetEnemySO(EnemyType.Tank).MoveSpeed;
        //_currentHealth = GetEnemySO(EnemyType.Tank).MaxHealth;

        //_stateMachine = new TankEnemyStateMachine(this);
        //_stateMachine.ChangeState(States.Idle);
    }

    public void UpdateEnemy()
    {
        _stateMachine.Update();
    }

    public void OnDamage(int damageAmount)
    {
        if (_tankEnemyModel.CurrentHealth > 0)
            _tankEnemyModel.CurrentHealth -= damageAmount;
        else
            _tankEnemyView.EnemyDead();
    }

    public float GetTankEnemyAgentSpeed() => _tankEnemyModel.MoveSpeed;
}
