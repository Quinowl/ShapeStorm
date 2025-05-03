using UnityEngine;

public class PlayerShootState : PlayerMovementState 
{

    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform projectilesPoolParent;
    private ObjectPool<BaseProjectile> projectilesPool;
    private bool canShoot = true;
    private float shootTimer = 0f;

    public override void StateEnter() 
    {
        base.StateEnter();
        if (projectilesPool == null) 
        {
            projectilesPool = new ObjectPool<BaseProjectile>(stateMachine.Player.Configuration.ProjectilePrefab, 10, projectilesPoolParent);
        }
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

    private void Shoot() {
        BaseProjectile projectile = projectilesPool.Get();
        //TODO: Arreglar este hardcodeo.
        projectile.SetBullet(25f,
                            3f,
                            3f,
                            shootPoint.position,
                            shootPoint.rotation,
                            () => projectilesPool.ReturnToPool(projectile));
        canShoot = false;
        shootTimer = stateMachine.Player.Configuration.ShootCadency;
    }
}