using UnityEngine;

public class CameraService : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private ShakeComponent _shake;
    [SerializeField] private CameraConfiguration _configuration;

    private Transform _target;
    private Vector3 _velocity;

    public void Initialize()
    {
        if (!_camera) _camera = Camera.main;
    }
    public void SetTarget(Transform newTarget) => _target = newTarget;
    public void ActivateShake() => _shake.Activate();
    public void FollowTarget()
    {
        Vector3 desiredPosition = _target.position + _configuration.offset;
        _camera.transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, _configuration.fovChangeSmoothTime);
        _camera.transform.LookAt(_target.position);
    }
}