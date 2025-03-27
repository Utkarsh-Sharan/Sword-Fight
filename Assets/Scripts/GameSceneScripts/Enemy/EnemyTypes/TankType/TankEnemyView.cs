public class TankEnemyView : EnemyView
{
    private TankEnemyController _tankEnemyController;

    public void Initialize(TankEnemyController tankEnemyController)
    {
        _tankEnemyController = tankEnemyController;

        enemyAgent.speed = _tankEnemyController.GetTankEnemyAgentSpeed();
    }

    private void Update() => _tankEnemyController.UpdateEnemy();

    public void BurstFootStep() => footStepVFX.Play();
    public void PlayAttackVFX() => attackVFX.Play();

    public override void OnDamage(int damageAmount) => _tankEnemyController.OnDamage(damageAmount);

    public void EnemyDead()
    {
        enemyAnimator.SetTrigger(ConstantStrings.DEATH_PARAMETER);
        EventService.Instance.OnEnemyDeathEvent.InvokeEvent();
        _tankEnemyController.CleanUp();
        Destroy(this);
    }
}
