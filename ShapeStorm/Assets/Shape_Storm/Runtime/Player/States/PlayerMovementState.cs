using UnityEngine;

public class PlayerMovementState : PlayerState {
    public override void StateEnter() { }
    public override void StateInputs() { }
    public override void CheckTransitions() {
        if (stateMachine.Player.InputHandler.MoveInput == Vector2.zero) stateMachine.SetState(typeof(PlayerIdleState));
        if (stateMachine.Player.InputHandler.ShootPressed) stateMachine.SetState(typeof(PlayerShootState));
    }
    public override void StateStep() { }
    public override void StateLateStep() { }
    public override void StatePhysicsStep() { }
    public override void StateExit() { }
}