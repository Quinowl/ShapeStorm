using UnityEngine;

public class PlayerMovementState : PlayerState {
    public override void StateEnter() { }
    public override void StateInputs() { }
    public override void CheckTransitions() {
        // if (stateMachine.Player.InputHandler.MoveInput == Vector2.zero) stateMachine.SetState(typeof(PlayerIdleState));
        // if (stateMachine.Player.InputHandler.ShootPressed) stateMachine.SetState(typeof(PlayerShootState));
    }
    public override void StateStep() {
        // Move(stateMachine.Player.InputHandler.MoveInput);
    }
    public override void StateLateStep() { }
    public override void StatePhysicsStep() { }
    public override void StateExit() { }

    private void Move(Vector2 _direction) {
        _direction.Normalize();
        Vector3 motion = new Vector3(_direction.x, 0f, _direction.y);
        stateMachine.Player.Move(stateMachine.Player.transform.position + motion * stateMachine.Player.Configuration.Speed * Time.deltaTime);
    }
}