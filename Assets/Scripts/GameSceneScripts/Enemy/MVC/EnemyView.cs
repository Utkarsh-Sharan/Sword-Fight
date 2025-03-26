using UnityEngine;
using UnityEngine.VFX;

public class EnemyView : MonoBehaviour, IDamageable
{
    [SerializeField] protected VisualEffect footStepVFX;
    [SerializeField] protected VisualEffect attackVFX;

    public virtual void OnDamage(int damageAmount) { }
}
