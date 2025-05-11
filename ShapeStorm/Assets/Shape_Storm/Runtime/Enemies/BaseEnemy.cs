using UnityEngine;

public abstract class BaseEnemy : Entity
{
    [SerializeField] private Transform[] _shootPoints;
    [SerializeField] private Transform _projectilesPoolParent;

    private ObjectPool<BaseProjectile> _projectiles;

    protected override void UpdateStep()
    {
        base.UpdateStep();
    }

    protected virtual void TryShoot()
    {

    }

    protected virtual void Shoot()
    {
        foreach (var point in _shootPoints)
        {
            BaseProjectile projectile = _projectiles.Get();

        }
    }
}