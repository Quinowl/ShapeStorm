using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private PoolService _poolService;

    private void OnEnable()
    {
        _poolService.Initialize();
        ServiceLocator.Instance.RegisterService(_poolService);
    }

    void OnDisable()
    {
        ServiceLocator.Instance.UnregisterService<PoolService>();
    }
}