public class PlayerStateMachine : GenericStateMachine<PlayerController>
{
    public PlayerStateMachine(PlayerController owner) : base(owner)
    {
        this.owner = owner;

        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        states.Add(States.Idle, new PlayerIdleState<PlayerController>(this));
        states.Add(States.Running, new PlayerRunningState<PlayerController>(this));
        states.Add(States.AirBourne, new PlayerAirBourneState<PlayerController>(this));
        states.Add(States.Attack, new PlayerAttackState<PlayerController>(this));
    }
}
