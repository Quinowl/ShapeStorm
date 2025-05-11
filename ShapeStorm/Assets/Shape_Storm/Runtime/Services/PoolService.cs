using UnityEngine;

public class PoolService : MonoBehaviour
{
    [SerializeField] private PoolData _playerProjectilesPoolData;
    private ObjectPool<PlayerProjectile> _playerProjectiles;
    public ObjectPool<PlayerProjectile> PlayerProjectiles => _playerProjectiles;

    public void Initialize()
    {
        _playerProjectiles = new ObjectPool<PlayerProjectile>(_playerProjectilesPoolData.TryGetComponentOnPrefab<PlayerProjectile>(), _playerProjectilesPoolData.initialSize, transform);
    }

}