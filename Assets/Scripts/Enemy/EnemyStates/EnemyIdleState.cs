using UnityEngine;

public class EnemyIdleState<T> : IState<T> where T : EnemyController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;
    private float _idleTime;
    private float _currentTime;

    public EnemyIdleState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        _idleTime = Owner.GetEnemySO(Owner.GetEnemyType()).IdleTime;
        Owner.GetEnemyAgent().isStopped = true;
        Owner.GetEnemyAnimator().SetFloat(ConstantStrings.SPEED_PARAMETER, 0);
    }

    public void Update()
    {
        if(Owner.IsPlayerDead()) 
            return;

        _currentTime += Time.deltaTime;
        if(_currentTime >= _idleTime)
            _stateMachine.ChangeState(States.Patrolling);

        if (Owner.IsPlayerInDetectionZone)
            _stateMachine.ChangeState(States.Chasing);
    }

    public void OnStateExit()
    {
        Owner.GetEnemyAgent().isStopped = false;
        _currentTime = 0f;
    }
}
