using UnityEngine;

public class Player : Entity {

    [SerializeField] private InputReader inputReader;
    [SerializeField] private PlayerStateMachine stateMachine;
    [field: SerializeField] public PlayerConfiguration Configuration { get; private set; }

    public Vector2 MoveInput { get; private set; }
    private void OnMoveInput(Vector2 _input) => MoveInput = _input;

    protected override void OnEnable() {
        base.OnEnable();
        inputReader.OnMoveEvent += OnMoveInput;
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
    }

    public void Move(Vector3 _nextPosition) => transform.position = _nextPosition;
}