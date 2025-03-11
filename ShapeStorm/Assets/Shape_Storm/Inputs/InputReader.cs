using UnityEngine;
using UnityEngine.InputSystem;
using System;

[CreateAssetMenu(menuName = "Scriptable Objects/Input Reader")]
public class InputReader : ScriptableObject {

    [SerializeField] private InputActionAsset asset;

    public Action<Vector2> OnMoveEvent;
    public Action OnShootEvent;
    public Action OnShootCancelledEvent;
    public Action OnPauseEvent;

    /// <summary>
    /// It will be called when the input device is changed.
    /// <para> True if it is gamepad, false if it is mouse.</para>
    /// </summary>
    public static Action<bool> OnInputDeviceChanged;

    private InputAction moveAction;
    private InputAction shootAction;
    private InputAction pauseAction;

    private string lastDeviceUsed;

    void OnEnable() {
        moveAction = asset.FindAction(Constants.Inputs.MOVE);
        shootAction = asset.FindAction(Constants.Inputs.SHOOT);
        pauseAction = asset.FindAction("Pause");
        Subscribe(true);
        SetEnable(true);
    }

    void OnDisable() {
        Subscribe(false);
        SetEnable(false);
    }

    private void ChangeInputAction(object _obj, InputActionChange _change) {
        if (_change == InputActionChange.ActionPerformed) {
            InputAction receivedInputAction = (InputAction)_obj;
            InputDevice currentDevice = receivedInputAction.activeControl.device;
            if (lastDeviceUsed == currentDevice.name) return;
            lastDeviceUsed = currentDevice.name;
            bool isGamepad = !(currentDevice.name.Equals("Keyboard") || currentDevice.name.Equals("Mouse"));
            OnInputDeviceChanged?.Invoke(isGamepad);
        }
    }

    private void Subscribe(bool _condition) {
        if (_condition) {
            moveAction.started += OnMove;
            moveAction.performed += OnMove;
            moveAction.canceled += OnMove;

            shootAction.started += OnShoot;
            shootAction.canceled += OnShoot;

            pauseAction.started += OnPause;

            InputSystem.onActionChange += ChangeInputAction;
        }
        else {
            moveAction.started -= OnMove;
            moveAction.performed -= OnMove;
            moveAction.canceled -= OnMove;

            shootAction.started -= OnShoot;
            shootAction.canceled -= OnShoot;

            pauseAction.started -= OnPause;

            InputSystem.onActionChange -= ChangeInputAction;
        }
    }

    private void SetEnable(bool _enable) {
        if (_enable) {
            moveAction.Enable();
            shootAction.Enable();
            pauseAction.Enable();
        }
        else {
            moveAction.Disable();
            shootAction.Disable();
            pauseAction.Disable();
        }
    }

    private void OnMove(InputAction.CallbackContext _context) => OnMoveEvent?.Invoke(_context.ReadValue<Vector2>());

    private void OnShoot(InputAction.CallbackContext _context) {
        if (OnShootEvent != null && _context.started) OnShootEvent?.Invoke();
        if (OnShootCancelledEvent != null && _context.canceled) OnShootCancelledEvent?.Invoke();
    }

    private void OnPause(InputAction.CallbackContext _context) => OnPauseEvent?.Invoke();
}