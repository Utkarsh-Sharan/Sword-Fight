using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyView : MonoBehaviour, IDamageable
{
    [SerializeField] protected EnemyType enemyType;

    [SerializeField] protected Animator enemyAnimator;
    [SerializeField] protected NavMeshAgent enemyAgent;
    [SerializeField] protected DamageApplier damageApplier;

    [SerializeField] protected VisualEffect footStepVFX;
    [SerializeField] protected VisualEffect attackVFX;
    protected List<Vector3> waypointsList;

    public virtual void OnDamage(int damageAmount) { }

    public Animator GetEnemyAnimator() => this.enemyAnimator;
    public NavMeshAgent GetEnemyAgent() => this.enemyAgent;
    public List<Vector3> GetWaypointsList() => this.waypointsList;
}
