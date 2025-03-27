using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour, IDamageable
{
    [SerializeField] protected NavMeshAgent enemyAgent;
    [SerializeField] protected Animator enemyAnimator;

    [SerializeField] protected VisualEffect footStepVFX;
    [SerializeField] protected VisualEffect attackVFX;

    public virtual void OnDamage(int damageAmount) { }
}
