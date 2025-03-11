using UnityEngine;

public class Player : Entity {

    [SerializeField] private InputReader inputReader;
    [SerializeField] private PlayerStateMachine stateMachine;
    [field: SerializeField] public PlayerConfiguration Configuration { get; private set; }

    #region Inputs
    public Vector2 MoveInput { get; private set; }
    private void OnMoveInput(Vector2 _input) => MoveInput = _input;
    public bool ShootInput { get; private set; }
    private void OnShootInput() {
        ShootInput = true;
        ShootInputReleased = false;
    }
    public bool ShootInputReleased { get; private set; }
    private void OnShootInputCancelled() {
        ShootInput = false;
        ShootInputReleased = true;
    }
    public bool IsGamepad { get; private set; }
    private void SetIsGamepad(bool _isGamepad) => IsGamepad = _isGamepad;
    #endregion

    protected override void OnEnable() {
        base.OnEnable();
        inputReader.OnMoveEvent += OnMoveInput;
        inputReader.OnShootEvent += OnShootInput;
        inputReader.OnShootCancelledEvent += OnShootInputCancelled;
        InputReader.OnInputDeviceChanged += SetIsGamepad;
    }

    protected override void Awake() {
        base.Awake();
    }

    protected override void Start() {
        base.Start();
        stateMachine.Configure(this);
        stateMachine.Initialize();
    }

    protected override void UpdateStep() {
        base.UpdateStep();
        stateMachine.Step();
        if (!IsGamepad) RotateTowardsMouse();
    }

    protected override void LateUpdateStep() {
        base.LateUpdateStep();
        stateMachine.LateStep();
    }

    protected override void FixedUpdateStep() {
        base.FixedUpdateStep();
        stateMachine.PhysicsStep();
    }

    protected override void OnDisable() {
        base.OnDisable();
        inputReader.OnMoveEvent -= OnMoveInput;
        inputReader.OnShootEvent -= OnShootInput;
        inputReader.OnShootCancelledEvent -= OnShootInputCancelled;
        InputReader.OnInputDeviceChanged -= SetIsGamepad;
    }

    public void Move(Vector3 _nextPosition) => transform.position = _nextPosition;

    private void RotateTowardsMouse() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, LayerMask.GetMask("Ground"))) {
            Vector3 targetPosition = hitInfo.point;
            targetPosition.y = transform.position.y;
            Vector3 direction = (targetPosition - transform.position).normalized;
            if (direction != Vector3.zero) {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = lookRotation;
            }
        }
    }
}