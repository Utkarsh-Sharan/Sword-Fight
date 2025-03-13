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
        states.Add(PlayerStates.Idle, new EnemyIdleState<EnemyController>(this));
        states.Add(PlayerStates.Walking, new EnemyWalkingState<EnemyController>(this));
        states.Add(PlayerStates.Chasing, new EnemyChasingState<EnemyController>(this));
        states.Add(PlayerStates.Attack, new EnemyAttackState<EnemyController>(this));
    }
}
