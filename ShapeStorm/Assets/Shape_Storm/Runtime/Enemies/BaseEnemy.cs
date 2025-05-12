using System.Collections;
using UnityEngine;

public abstract class BaseEnemy : Entity
{
    [SerializeField] protected BaseEnemyConfiguration _configuration;
    [SerializeField] private Transform[] _shootPoints;

    protected bool _canShoot;

    private PoolService _poolService;
    private Coroutine _shootCandencyCoroutine;

    protected override void Start()
    {
        base.Start();
        _canShoot = true;
        _poolService = ServiceLocator.Instance.GetService<PoolService>();
    }

    protected override void UpdateStep()
    {
        base.UpdateStep();
        TryShoot();
    }

    protected virtual void TryShoot()
    {
        if (_canShoot)
        {
            Shoot();
            if (_shootCandencyCoroutine != null) StopCoroutine(_shootCandencyCoroutine);
            _shootCandencyCoroutine = StartCoroutine(StartShootCadencyCoroutine());
        }
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

    private IEnumerator StartShootCadencyCoroutine()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_configuration.shootCadency);
        _canShoot = true;
    }
}