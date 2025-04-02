public class TankEnemyModel
{
    public int CurrentHealth { get; set; }
    public float MoveSpeed { get; }
    public float AttackTime { get; }
    public float ChaseDelay { get; }
    public float IdleTime { get; }
    public int AttackDamage { get; }

    public TankEnemyModel(EnemyScriptableObject tankEnemySO)
    {
        CurrentHealth = tankEnemySO.MaxHealth;
        MoveSpeed = tankEnemySO.MoveSpeed;
        AttackTime = tankEnemySO.AttackTime;
        ChaseDelay = tankEnemySO.ChaseDelay;
        IdleTime = tankEnemySO.IdleTime;
        AttackDamage = tankEnemySO.AttackDamage;
    }
}
