using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour {

    [SerializeField] private PlayerInput playerInput;

    private InputAction movementInputAction;
    private InputAction shootInputAction;

    public Vector2 MoveInput { get; private set; }
    public bool ShootPressed { get; private set; }
    public bool ShootReleased { get; private set; }

    private void Awake() {
        InitializeInputs();
    }

    private void Update() {
        ReadInputs();
    }

    private void InitializeInputs() {
        movementInputAction = playerInput.actions[Constants.Inputs.MOVE];
        shootInputAction = playerInput.actions[Constants.Inputs.SHOOT];
    }

    private void ReadInputs() {
        MoveInput = movementInputAction.ReadValue<Vector2>();
        ShootPressed = shootInputAction.WasPressedThisFrame();
        ShootReleased = shootInputAction.WasReleasedThisFrame();
    }
}