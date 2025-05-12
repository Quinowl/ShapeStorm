using UnityEngine;

public class PlayerShootState : PlayerMovementState
{
    [SerializeField] private Transform _shootPoint;
    private bool _canShoot = true;
    private float _shootTimer = 0f;

    private PoolService _poolService;

    public override void StateEnter()
    {
        base.StateEnter();
        if (!_poolService) _poolService = ServiceLocator.Instance.GetService<PoolService>();
    }

    public override void CheckTransitions()
    {
        if (_stateMachine.Player.ShootInputReleased)
        {
            _stateMachine.SetState(_stateMachine.Player.MoveInput == Vector2.zero ? typeof(PlayerIdleState) : typeof(PlayerMovementState));
        }
    }

    public override void StateStep()
    {
        base.StateStep();
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (!_canShoot)
        {
            _shootTimer -= Time.deltaTime;
            if (_shootTimer <= 0f) _canShoot = true;
            return;
        }
        if (_stateMachine.Player.ShootInput) Shoot();
    }

    private void Shoot()
    {
        PlayerProjectile projectile = _poolService.PlayerProjectiles.Get();
        //TODO: Arreglar este hardcodeo.
        projectile.SetBullet(_stateMachine.Player.Configuration.projectileSpeed,
                            _stateMachine.Player.Configuration.projectileDamage,
                            _stateMachine.Player.Configuration.projectileLifeTime,
                            _shootPoint.position,
                            _shootPoint.rotation,
                            () => _poolService.PlayerProjectiles.ReturnToPool(projectile));
        _canShoot = false;
        _shootTimer = _stateMachine.Player.Configuration.shootCadency;
    }
}