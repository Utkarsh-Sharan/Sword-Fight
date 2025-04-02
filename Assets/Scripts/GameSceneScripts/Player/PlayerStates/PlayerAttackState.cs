using UnityEngine;

public class PlayerAttackState<T> : IState<T> where T : PlayerController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;
    private float _currentTime;
    private float _attackTime;

    public PlayerAttackState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        _attackTime = Owner.GetPlayerSO().AttackTime;
        Owner.GetPlayerAnimator().SetTrigger(ConstantStrings.ATTACK_PARAMETER);
    }

    public void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime >= _attackTime) 
            _stateMachine.ChangeState(States.Idle);
    }

    public void OnStateExit()
    {
        _currentTime = 0f;
    }
}
