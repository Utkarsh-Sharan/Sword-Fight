public class TankEnemyView : EnemyView
{
    public void BurstFootStep() => footStepVFX.Play();
    public void PlayAttackVFX() => attackVFX.Play();

    //public override void OnDamage(int damageAmount) => _tankEnemyController.OnDamage(damageAmount);
}
