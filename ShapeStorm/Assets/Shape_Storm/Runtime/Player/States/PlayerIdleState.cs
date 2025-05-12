using UnityEngine;

public class PlayerIdleState : PlayerState
{

    public override void StateEnter() { }
    public override void StateInputs() { }
    public override void CheckTransitions()
    {
        if (_stateMachine.Player.MoveInput != Vector2.zero) _stateMachine.SetState(typeof(PlayerMovementState));
        if (_stateMachine.Player.ShootInput) _stateMachine.SetState(typeof(PlayerShootState));
    }
    public override void StateStep() { }
    public override void StateLateStep() { }
    public override void StatePhysicsStep() { }
    public override void StateExit() { }
}