using UnityEngine;

public class PlayerProjectile : BaseProjectile
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }
        if (other.TryGetComponent(out NonDestroyableEnemyProjectile _)) return;
        // Si colisiona con balas del enemigo que no son destruibles, se hace return
        _destroyAction?.Invoke();
    }
}