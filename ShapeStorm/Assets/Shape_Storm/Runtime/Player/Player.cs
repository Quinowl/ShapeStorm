using System;
using UnityEngine;

public class Player : Entity {

    [SerializeField] private PlayerStateMachine stateMachine;
    public InputHandler InputHandler { get; private set; }
    [field: SerializeField] public PlayerConfiguration Configuration { get; private set; }

    protected override void Awake() {
        base.Awake();
        InputHandler = ServiceLocator.Instance.GetService<InputHandler>();
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

    public void Move(Vector3 _nextPosition) => transform.position = _nextPosition;
}