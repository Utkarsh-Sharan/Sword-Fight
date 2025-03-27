public class TankEnemyModel : EnemyModel
{
    public int CurrentHealth { get; set; }
    public float MoveSpeed { get; }
    public float AttackTime { get; }
    public float ChaseDelay { get; }
    public float IdleTime { get; }

    protected int damageAmount;
    public int AttackDamage;

    private TankEnemyController _tankEnemyController;

    public TankEnemyModel(EnemyScriptableObject tankEnemySO) : base()
    {
        CurrentHealth = tankEnemySO.MaxHealth;
    }
}
