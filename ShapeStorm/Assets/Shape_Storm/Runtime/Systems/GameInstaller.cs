using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private PoolService _poolService;
    [SerializeField] private CameraService _cameraService;

    private void OnEnable()
    {
        _poolService.Initialize();
        _cameraService.Initialize();
        ServiceLocator.Instance.RegisterService(_poolService);
        ServiceLocator.Instance.RegisterService(_cameraService);
    }

    void OnDisable()
    {
        ServiceLocator.Instance.UnregisterService<PoolService>();
        ServiceLocator.Instance.UnregisterService<CameraService>();
    }
}