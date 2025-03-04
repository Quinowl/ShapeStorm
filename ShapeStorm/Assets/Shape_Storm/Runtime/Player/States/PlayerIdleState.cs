using UnityEngine;

public class PlayerIdleState : PlayerState {

    public override void StateEnter() { }
    public override void StateInputs() { }
    public override void CheckTransitions() {
        if (stateMachine.Player.InputHandler.MoveInput != Vector2.zero)
            stateMachine.SetState(typeof(PlayerMovementState));
    }
    public override void StateStep() { }
    public override void StateLateStep() { }
    public override void StatePhysicsStep() { }
    public override void StateExit() { }
}