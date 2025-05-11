using UnityEngine;

public class PlayerShootState : PlayerMovementState
{
    [SerializeField] private Transform shootPoint;
    private bool canShoot = true;
    private float shootTimer = 0f;

    private PoolService _poolService;

    public override void StateEnter()
    {
        base.StateEnter();
        if (!_poolService) _poolService = ServiceLocator.Instance.GetService<PoolService>();
    }

    public override void CheckTransitions()
    {
        if (stateMachine.Player.ShootInputReleased)
        {
            stateMachine.SetState(stateMachine.Player.MoveInput == Vector2.zero ? typeof(PlayerIdleState) : typeof(PlayerMovementState));
        }
    }

    public override void StateStep()
    {
        base.StateStep();
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (!canShoot)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f) canShoot = true;
            return;
        }
        if (stateMachine.Player.ShootInput) Shoot();
    }

    private void Shoot()
    {
        PlayerProjectile projectile = _poolService.PlayerProjectiles.Get();
        //TODO: Arreglar este hardcodeo.
        projectile.SetBullet(25f,
                            3f,
                            3f,
                            shootPoint.position,
                            shootPoint.rotation,
                            () => _poolService.PlayerProjectiles.ReturnToPool(projectile));
        canShoot = false;
        shootTimer = stateMachine.Player.Configuration.ShootCadency;
    }
}