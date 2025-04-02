using System.Collections.Generic;
using UnityEngine;

public class TankEnemyView : EnemyView
{
    private TankEnemyController _tankEnemyController;

    public void Initialize(TankEnemyController tankEnemyController, List<Vector3> waypointsList)
    {
        _tankEnemyController = tankEnemyController;

        enemyAgent.enabled = false;
        this.waypointsList = waypointsList;
        enemyAgent.enabled = true;

        enemyAgent.speed = _tankEnemyController.GetTankEnemyAgentSpeed();
        damageApplier.enabled = false;
    }

    private void Update() => _tankEnemyController.UpdateEnemy();

    #region Animation Events
    public void EnemyAttackStart() 
    {
        damageApplier.enabled = true;
        EventService.Instance.OnDamageEvent.AddListener(_tankEnemyController.OnAttack);
    } 
    public void EnemyAttackEnd()
    {
        damageApplier.enabled = false;
        EventService.Instance.OnDamageEvent.RemoveListener(_tankEnemyController.OnAttack);
    }
    public void BurstFootStep() => footStepVFX.Play();
    public void PlayAttackVFX() => attackVFX.Play();
    #endregion

    public override void OnDamage(int damageAmount) => _tankEnemyController.OnDamage(damageAmount);

    public void EnemyDead()
    {
        EventService.Instance.OnEnemyDeathEvent.InvokeEvent();
        enemyAnimator.SetTrigger(ConstantStrings.DEATH_PARAMETER);
        _tankEnemyController.RemoveListeners();

        Destroy(this);
    }
}
