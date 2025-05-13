using UnityEngine;

public class CameraService : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private ShakeComponent _shake;
    [SerializeField] private CameraConfiguration _configuration;

    private Transform _target;
    private Vector3 _velocity;
    private float _currentZoom;
    private float _defaultFov;
    private float _targetFov;

    public void Initialize()
    {
        if (!_camera) _camera = Camera.main;
        _defaultFov = _camera.fieldOfView;
        _currentZoom = _defaultFov;
    }

    public void SetTarget(Transform newTarget) => _target = newTarget;
    public void ActivateShake() => _shake.Activate();

    public void FollowTarget(Vector2 moveInput)
    {
        if (!_target) return;

        Vector3 desiredPosition = _target.position + _configuration.offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, _configuration.followSmoothTime);

        float moveMagnitude = moveInput.magnitude;
        _targetFov = Mathf.Lerp(_defaultFov, _defaultFov + _configuration.zoomOutAmount, moveMagnitude);
        _currentZoom = Mathf.Lerp(_currentZoom, _targetFov, Time.deltaTime * _configuration.zoomSmoothSpeed);
        _camera.fieldOfView = _currentZoom;
    }
}