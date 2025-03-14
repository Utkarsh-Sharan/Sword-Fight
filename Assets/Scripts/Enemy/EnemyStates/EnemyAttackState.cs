using UnityEngine;

public class EnemyAttackState<T> : IState<T> where T : EnemyController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;
    private float _attackTime = 2.267f;
    private float _currentTime;

    public EnemyAttackState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Owner.GetEnemyAgent().isStopped = true;
    }

    public void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime <= _attackTime && IsPlayerWithinStoppingDistance())
            Owner.GetEnemyAnimator().SetTrigger(ConstantStrings.PLAYER_ATTACK_PARAMETER);
        else
            _stateMachine.ChangeState(States.Chasing);

    }

    public void OnStateExit()
    {
        _currentTime = 0f;
        Owner.GetEnemyAgent().isStopped = false;
    }

    private bool IsPlayerWithinStoppingDistance() => Vector3.Distance(Owner.GetPlayerPosition(), Owner.transform.position) <= Owner.GetEnemyAgent().stoppingDistance;
}
