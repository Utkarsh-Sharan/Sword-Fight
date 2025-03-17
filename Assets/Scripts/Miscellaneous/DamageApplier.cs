using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageApplier : MonoBehaviour
{
    [SerializeField] private BoxCollider _damageCollider;

    private void Start()
    {
        _damageCollider.enabled = false;
    }

    private void OnEnable()
    {
        _damageCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if(damageable is EnemyController)
            {
                PlayerController controller = damageable as PlayerController;
                int damageAmount = 30;
                controller.OnDamage(damageAmount);
            }
            if(damageable is PlayerController)
            {
                EnemyController controller = damageable as EnemyController;
                int damageAmount = controller.GetEnemySO(controller.GetEnemyType()).AttackDamage;
                damageable.OnDamage(damageAmount);
            }
        }
    }

    private void OnDisable()
    {
        _damageCollider.enabled = false;
    }
}
