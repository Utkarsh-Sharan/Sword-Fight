using UnityEngine;

public class DamageApplier : MonoBehaviour
{
    [SerializeField] private BoxCollider _damageCollider;

    private void Start()
    {
        this.enabled = false;
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
            damageable.OnDamage();
        }
    }

    private void OnDisable()
    {
        _damageCollider.enabled = false;
    }
}
