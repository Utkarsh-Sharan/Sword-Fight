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
        Owner.GetEnemyAgent().isStopped = true;
        Owner.GetEnemyAnimator().SetFloat(ConstantStrings.RUN_PARAMETER, 0);
    }

    public void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= _idleTime)
        {
            Owner.GetEnemyAgent().isStopped = false;
            _stateMachine.ChangeState(States.Patrolling);
        }

        if (Owner.IsPlayerInRange)
        {
            Owner.GetEnemyAgent().isStopped = false;
            _stateMachine.ChangeState(States.Chasing);
        }
    }

    public void OnStateExit()
    {
        Owner.GetEnemyAgent().isStopped = false;
        _currentTime = 0f;
    }
}
