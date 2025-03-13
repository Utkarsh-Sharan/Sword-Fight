using UnityEngine;

public class EnemyIdleState<T> : IState<T> where T : EnemyController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;
    private float _idleTime = 2.7f;
    private float _currentTime;

    public EnemyIdleState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Owner.GetEnemyAnimator().SetFloat(ConstantStrings.RUN_PARAMETER, 0);
    }

    public void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= _idleTime)
        {
            _stateMachine.ChangeState(States.Patrolling);
        }
        //Will do later: if player detected, start chasing.
    }

    public void OnStateExit()
    {
        _currentTime = 0f;
    }
}
