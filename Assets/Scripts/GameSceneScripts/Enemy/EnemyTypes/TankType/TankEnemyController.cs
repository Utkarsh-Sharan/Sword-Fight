using System.Collections.Generic;
using UnityEngine;

public class TankEnemyController : EnemyController
{
    private TankEnemyModel _tankEnemyModel;
    private TankEnemyView _tankEnemyView;
    private TankEnemyStateMachine _stateMachine;

    public TankEnemyController(EnemyScriptableObject tankEnemySO, Vector3 spawnPosition, List<Vector3> waypointsList) : base(tankEnemySO)
    {
        SetModelAndView(tankEnemySO, spawnPosition, waypointsList);
        SetStateMachine();
    }

    private void SetModelAndView(EnemyScriptableObject tankEnemySO, Vector3 spawnPosition, List<Vector3> waypointsList)
    {
        _tankEnemyModel = new TankEnemyModel(tankEnemySO);

        _tankEnemyView = (TankEnemyView)Object.Instantiate(tankEnemySO.EnemyView);
        _tankEnemyView.Initialize(this, spawnPosition, waypointsList);
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
