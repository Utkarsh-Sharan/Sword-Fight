using UnityEngine;

public class EnemyChasingState<T> : IState<T> where T : EnemyController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;
    private Vector3 _destination;

    public EnemyChasingState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Owner.GetEnemyAnimator().SetFloat(ConstantStrings.RUN_PARAMETER, 2);
    }

    public void Update()
    {
        MoveTowardsPlayer();

        if (!Owner.IsPlayerInRange)
        {
            //Owner.GetEnemyAgent().isStopped = true;
            _stateMachine.ChangeState(States.Idle);
        }

        if (ReachedPlayer())
            _stateMachine.ChangeState(States.Attack);
    }

    public void OnStateExit()
    {
        //Owner.GetEnemyAgent().isStopped = true;
    }

    private void MoveTowardsPlayer()
    {
        _destination = Owner.GetPlayerPosition();
        Owner.GetEnemyAgent().SetDestination(_destination);
    }

    private bool ReachedPlayer() => Owner.GetEnemyAgent().remainingDistance <= Owner.GetEnemyAgent().stoppingDistance;
}
