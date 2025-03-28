using UnityEngine;

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

    #region Getters
    public float GetTankEnemyAgentSpeed() => _tankEnemyModel.MoveSpeed;
    public float GetTankEnemyAttackTime() => _tankEnemyModel.AttackTime;
    public float GetTankEnemyChaseDelay() => _tankEnemyModel.ChaseDelay;
    public float GetTankEnemyIdleTime() => _tankEnemyModel.IdleTime;
    #endregion
}
