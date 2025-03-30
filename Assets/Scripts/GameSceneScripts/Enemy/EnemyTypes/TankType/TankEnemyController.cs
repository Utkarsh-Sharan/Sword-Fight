using UnityEngine;

public class TankEnemyController : EnemyController
{
    private TankEnemyModel _tankEnemyModel;
    private TankEnemyView _tankEnemyView;
    private TankEnemyStateMachine _stateMachine;

    public TankEnemyController(EnemyScriptableObject tankEnemySO) : base(tankEnemySO)
    {
        SetModelAndView(tankEnemySO);
        SetStateMachine();
    }

    private void SetModelAndView(EnemyScriptableObject tankEnemySO)
    {
        _tankEnemyModel = new TankEnemyModel(tankEnemySO);

        _tankEnemyView = (TankEnemyView)Object.Instantiate(tankEnemySO.EnemyView);
        _tankEnemyView.Initialize(this);
        _tankEnemyView.transform.position = tankEnemySO.SpawnPosition;
        _tankEnemyView.transform.rotation = tankEnemySO.SpawnRotation;
        enemyView = _tankEnemyView;
    }

    private void SetStateMachine()
    {
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
    #endregion
}
