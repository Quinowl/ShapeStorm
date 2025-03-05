using UnityEngine;
using UnityEngine.InputSystem;
using System;

[CreateAssetMenu(menuName = "Scriptable Objects/Input Reader")]
public class InputReader : ScriptableObject {

    [SerializeField] private InputActionAsset asset;

    public Action<Vector2> OnMoveEvent;
    public Action OnShootEvent;
    public Action OnShootCancelledEvent;

    private InputAction moveAction;
    private InputAction shootAction;

    void OnEnable() {
        moveAction = asset.FindAction(Constants.Inputs.MOVE);
        shootAction = asset.FindAction(Constants.Inputs.SHOOT);
        Subscribe(true);
        SetEnable(true);
    }

    void OnDisable() {
        Subscribe(false);
        SetEnable(false);
    }

    private void Subscribe(bool _condition) {
        if (_condition) {
            moveAction.started += OnMove;
            moveAction.performed += OnMove;
            moveAction.canceled += OnMove;

            shootAction.started += OnShoot;
            shootAction.canceled += OnShoot;
        }
        else {
            moveAction.started -= OnMove;
            moveAction.performed -= OnMove;
            moveAction.canceled -= OnMove;

            shootAction.started -= OnShoot;
            shootAction.canceled -= OnShoot;
        }
    }

    private void SetEnable(bool _enable) {
        if (_enable) {
            moveAction.Enable();
            shootAction.Enable();
        }
        else {
            moveAction.Disable();
            shootAction.Disable();
        }
    }

    private void OnMove(InputAction.CallbackContext _context) {
        OnMoveEvent?.Invoke(_context.ReadValue<Vector2>());
    }

    private void OnShoot(InputAction.CallbackContext _context) {
        if (OnShootEvent != null && _context.started) OnShootEvent?.Invoke();
        if (OnShootCancelledEvent != null && _context.canceled) OnShootCancelledEvent?.Invoke();
    }
}