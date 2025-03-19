public class TankEnemyStateMachine : GenericStateMachine<TankEnemyController>
{
    public TankEnemyStateMachine(TankEnemyController owner) : base(owner)
    {
        this.owner = owner;

        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        states.Add(States.Idle, new EnemyIdleState<TankEnemyController>(this));
        states.Add(States.Patrolling, new EnemyPatrollingState<TankEnemyController>(this));
        states.Add(States.Chasing, new EnemyChasingState<TankEnemyController>(this));
        states.Add(States.Attack, new EnemyAttackState<TankEnemyController>(this));
    }
}
