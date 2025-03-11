public class PlayerAttackState<T> : IState<T> where T : PlayerController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;

    public PlayerAttackState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        
    }

    public void Update()
    {
        Owner.GetPlayerAnimator().SetTrigger(ConstantStrings.PLAYER_ATTACK_PARAMETER);
        _stateMachine.ChangeState(PlayerStates.Idle);
    }

    public void OnStateExit()
    {
        
    }
}
