using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour {

    [SerializeField] private PlayerInput playerInput;

    private InputAction movementInputAction;

    public Vector2 MoveInput { get; private set; }

    private void Awake() {
        InitializeInputs();
    }

    private void Update() {
        ReadInputs();
    }

    private void InitializeInputs() {
        movementInputAction = playerInput.actions["Move"];
    }

    private void ReadInputs() {
        MoveInput = movementInputAction.ReadValue<Vector2>();
    }
}