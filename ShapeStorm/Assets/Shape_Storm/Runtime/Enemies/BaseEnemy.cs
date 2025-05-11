using UnityEngine;

public abstract class BaseEnemy : Entity
{
    [SerializeField] private BaseEnemyConfiguration _configuration;
    [SerializeField] private Transform[] _shootPoints;
    [SerializeField] private Transform _projectilesPoolParent;

    private PoolService _poolService;

    protected override void Awake()
    {
        base.Awake();
        _poolService = ServiceLocator.Instance.GetService<PoolService>();
    }

    protected override void UpdateStep()
    {
        base.UpdateStep();
    }

    protected virtual void TryShoot()
    {

    }

    protected virtual void Shoot()
    {
        foreach (Transform point in _shootPoints)
        {
            BaseProjectile projectile;
            bool isDestroyable;
            if (Random.value <= _configuration.destroyableProjectileProb)
            {
                isDestroyable = true;
                projectile = _poolService.DestroyableEnemyProjectiles.Get();
            }
            else
            {
                isDestroyable = false;
                projectile = _poolService.NonDestroyableEnemyProjectiles.Get();
            }
            projectile.SetBullet(_configuration.projectileSpeed, _configuration.projectileDamage, _configuration.projectileLifeTime, point.position, point.rotation, GetDestroyAction(projectile, isDestroyable));
        }
    }

    private System.Action GetDestroyAction(BaseProjectile projectile, bool isDestroyable)
    {
        return isDestroyable ?
            () => _poolService.DestroyableEnemyProjectiles.ReturnToPool(projectile as DestroyableEnemyProjectile) :
            () => _poolService.NonDestroyableEnemyProjectiles.ReturnToPool(projectile as NonDestroyableEnemyProjectile);
    }
}