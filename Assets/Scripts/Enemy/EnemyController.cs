using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _enemyAgent;
    private Animator _enemyAnimator;
    private Transform _playerTransform;
    private float _moveSpeed = 2f;

    public void Initialze(NavMeshAgent enemyAgent, Animator enemyAnimator)
    {
        _enemyAgent = enemyAgent;
        _enemyAnimator = enemyAnimator;

        _enemyAgent.speed = _moveSpeed;
    }

    public void Dependency(PlayerService playerService)
    {
        _playerTransform = playerService.GetPlayerTransform();
    }

    private void FixedUpdate()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        if(Vector3.Distance(this.transform.position, _playerTransform.position) >= _enemyAgent.stoppingDistance)
        {
            _enemyAgent.SetDestination(_playerTransform.position);
            _enemyAnimator.SetFloat(ConstantStrings.RUN_PARAMETER, _moveSpeed);
        }
        else
        {
            _enemyAgent.SetDestination(this.transform.position);
            _enemyAnimator.SetFloat(ConstantStrings.RUN_PARAMETER, 0);
        }
    }
}
