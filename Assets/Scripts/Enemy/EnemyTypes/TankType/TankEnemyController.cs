using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankEnemyController : EnemyController
{
    private TankEnemyStateMachine _stateMachine;
    private int _currentHealth;
    private int _damageAmount;

    public override void Initialize(NavMeshAgent enemyAgent, Animator enemyAnimator, List<EnemyScriptableObject> enemySOList)
    {
        base.Initialize(enemyAgent, enemyAnimator, enemySOList);

        this.enemyAgent.speed = GetEnemySO(EnemyType.Tank).MoveSpeed;
        _currentHealth = GetEnemySO(EnemyType.Tank).MaxHealth;

        _stateMachine = new TankEnemyStateMachine(this);
        _stateMachine.ChangeState(States.Idle);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public override void OnDamage()
    {
        _damageAmount = playerSO.AttackDamage;

        if (_currentHealth > 0)
            _currentHealth -= _damageAmount;
        else
            EnemyDead();
    }

    private void EnemyDead()
    {
        this.enemyAnimator.SetTrigger(ConstantStrings.DEATH_PARAMETER);
        Destroy(this);
    }
}
