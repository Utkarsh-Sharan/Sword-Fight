using UnityEngine;

public class EnemyAttackState<T> : IState<T> where T : EnemyController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;
    private float _attackTime;
    private float _chasingDelay;
    private float _currentTime;
    private float _outOfRangeTime;

    private Transform _playerTransform;

    public EnemyAttackState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        _playerTransform = EventService.Instance.OnGetPlayerTransformEvent.InvokeEvent();

        _attackTime = Owner.GetEnemySO(Owner.GetEnemyType()).AttackTime;
        _chasingDelay = Owner.GetEnemySO(Owner.GetEnemyType()).ChaseDelay;

        Owner.GetEnemyAgent().isStopped = true;
        Owner.GetEnemyAnimator().SetTrigger(ConstantStrings.ATTACK_PARAMETER);
    }

    public void Update()
    {
        _currentTime += Time.deltaTime;
        Owner.GetEnemyTransform().rotation = Quaternion.Slerp(Owner.GetEnemyTransform().rotation, Quaternion.LookRotation(_playerTransform.position - Owner.GetEnemyTransform().position), 0.1f);
        
        if (IsPlayerWithinStoppingDistance())
        {
            _outOfRangeTime = 0;
            if(_currentTime >= _attackTime)
            {
                Owner.GetEnemyAnimator().SetTrigger(ConstantStrings.ATTACK_PARAMETER);
                _currentTime = 0f;
            }
        }
        else
        {
            _outOfRangeTime += Time.deltaTime;
            if(_outOfRangeTime >= _chasingDelay)
                _stateMachine.ChangeState(States.Chasing);
        }
        if (Owner.IsPlayerDead())
            _stateMachine.ChangeState(States.Idle);
    }

    public void OnStateExit()
    {
        _currentTime = 0f;
        _outOfRangeTime = 0f;
        Owner.GetEnemyAgent().isStopped = false;
    }

    private bool IsPlayerWithinStoppingDistance() => Vector3.Distance(_playerTransform.position, Owner.GetEnemyTransform().position) <= Owner.GetEnemyAgent().stoppingDistance;
}
