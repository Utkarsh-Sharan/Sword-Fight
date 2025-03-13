public class EnemyStateMachine : GenericStateMachine<EnemyController>
{
    public EnemyStateMachine(EnemyController owner) : base(owner)
    {
        this.owner = owner;

        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        states.Add(States.Idle, new EnemyIdleState<EnemyController>(this));
        states.Add(States.Patrolling, new EnemyPatrollingState<EnemyController>(this));
        states.Add(States.Chasing, new EnemyChasingState<EnemyController>(this));
        states.Add(States.Attack, new EnemyAttackState<EnemyController>(this));
    }
}
