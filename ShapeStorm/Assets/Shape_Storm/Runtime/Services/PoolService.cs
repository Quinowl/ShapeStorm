using UnityEngine;

public class PoolService : MonoBehaviour
{
    [SerializeField] private PoolData _playerProjectilesPoolData;
    [SerializeField] private PoolData _enemyDestroyableProjectilesPoolData;
    [SerializeField] private PoolData _enemyNonDestroyableProjectilesPoolData;

    private ObjectPool<PlayerProjectile> _playerProjectiles;
    private ObjectPool<DestroyableEnemyProjectile> _enemyDestroyableProjectiles;
    private ObjectPool<NonDestroyableEnemyProjectile> _enemyNonDestroyableProjectiles;

    public ObjectPool<PlayerProjectile> PlayerProjectiles => _playerProjectiles;
    public ObjectPool<DestroyableEnemyProjectile> DestroyableEnemyProjectiles => _enemyDestroyableProjectiles;
    public ObjectPool<NonDestroyableEnemyProjectile> NonDestroyableEnemyProjectiles => _enemyNonDestroyableProjectiles;

    public void Initialize()
    {
        _playerProjectiles = new ObjectPool<PlayerProjectile>(_playerProjectilesPoolData.TryGetComponentOnPrefab<PlayerProjectile>(), _playerProjectilesPoolData.initialSize, transform);
        _enemyDestroyableProjectiles = new ObjectPool<DestroyableEnemyProjectile>(_enemyDestroyableProjectilesPoolData.TryGetComponentOnPrefab<DestroyableEnemyProjectile>(), _enemyDestroyableProjectilesPoolData.initialSize, transform);
        _enemyNonDestroyableProjectiles = new ObjectPool<NonDestroyableEnemyProjectile>(_enemyNonDestroyableProjectilesPoolData.TryGetComponentOnPrefab<NonDestroyableEnemyProjectile>(), _enemyDestroyableProjectilesPoolData.initialSize, transform);
    }
}