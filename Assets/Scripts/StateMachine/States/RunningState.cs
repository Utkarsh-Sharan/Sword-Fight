using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState<T> : IState<T> where T : class
{
    public T Owner { get; set; }

    private GenericStateMachine<T> _stateMachine;
    private Animator _playerAnimator;
    private float _movementMagnitude;

    public RunningState(GenericStateMachine<T> stateMachine, Animator playerAnimator, float movementMagnitude)
    {
        _stateMachine = stateMachine;
        _playerAnimator = playerAnimator;
        _movementMagnitude = movementMagnitude;
    }

    public void OnStateEnter()
    {
        
    }

    public void Update()
    {
        if (_movementMagnitude <= 0f)
            _stateMachine.ChangeState(States.Idle);

        _playerAnimator.SetFloat(ConstantStrings.RUN_PARAMETER, _movementMagnitude);
    }

    public void OnStateExit()
    {
        
    }
}
