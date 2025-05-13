using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private PoolService _poolService;
    [SerializeField] private CameraService _cameraService;
    [SerializeField] private WorldReferencesService _worldService;

    private void OnEnable()
    {
        _poolService.Initialize();
        _cameraService.Initialize();
        ServiceLocator.Instance.RegisterService(_poolService);
        ServiceLocator.Instance.RegisterService(_cameraService);
        ServiceLocator.Instance.RegisterService(_worldService);
    }

    void OnDisable()
    {
        ServiceLocator.Instance.UnregisterService<PoolService>();
        ServiceLocator.Instance.UnregisterService<CameraService>();
        ServiceLocator.Instance.UnregisterService<WorldReferencesService>();
    }
}