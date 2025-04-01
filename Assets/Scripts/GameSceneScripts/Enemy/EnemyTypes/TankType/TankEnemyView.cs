using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyView : EnemyView
{
    private TankEnemyController _tankEnemyController;

    public void Initialize(TankEnemyController tankEnemyController, Vector3 spawnPosition, List<Vector3> waypointsList)
    {
        _tankEnemyController = tankEnemyController;

        transform.position = spawnPosition;
        this.waypointsList = waypointsList;

        enemyAgent.speed = _tankEnemyController.GetTankEnemyAgentSpeed();
        damageApplier.enabled = false;
    }

    private void Update() => _tankEnemyController.UpdateEnemy();

    #region Animation Events
    public void EnemyAttackStart() => damageApplier.enabled = true;
    public void EnemyAttackEnd() => damageApplier.enabled = false;
    public void BurstFootStep() => footStepVFX.Play();
    public void PlayAttackVFX() => attackVFX.Play();
    #endregion

    public override void OnDamage(int damageAmount) => _tankEnemyController.OnDamage(damageAmount);

    public void EnemyDead()
    {
        enemyAnimator.SetTrigger(ConstantStrings.DEATH_PARAMETER);
        EventService.Instance.OnEnemyDeathEvent.InvokeEvent();
        _tankEnemyController.RemoveListeners();

        Destroy(this);
    }
}
