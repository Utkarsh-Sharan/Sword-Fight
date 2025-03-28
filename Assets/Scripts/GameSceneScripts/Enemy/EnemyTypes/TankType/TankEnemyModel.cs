public class TankEnemyModel : EnemyModel
{
    public int CurrentHealth { get; set; }
    public float MoveSpeed { get; }
    public float AttackTime { get; }
    public float ChaseDelay { get; }
    public float IdleTime { get; }

    private int damageAmount;
    public int AttackDamage;

    public TankEnemyModel(EnemyScriptableObject tankEnemySO) : base()
    {
        CurrentHealth = tankEnemySO.MaxHealth;
        AttackTime = tankEnemySO.AttackTime;
        ChaseDelay = tankEnemySO.ChaseDelay;
        IdleTime = tankEnemySO.IdleTime;
    }
}
