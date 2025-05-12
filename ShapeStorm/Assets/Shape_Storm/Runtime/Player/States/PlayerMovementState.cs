using UnityEngine;

public class PlayerMovementState : PlayerState
{
    public override void StateEnter() { }
    public override void StateInputs() { }
    public override void CheckTransitions()
    {
        if (_stateMachine.Player.MoveInput == Vector2.zero) _stateMachine.SetState(typeof(PlayerIdleState));
        if (_stateMachine.Player.ShootInput) _stateMachine.SetState(typeof(PlayerShootState));
    }
    public override void StateStep()
    {
        Move(_stateMachine.Player.MoveInput);
    }
    public override void StateLateStep() { }
    public override void StatePhysicsStep() { }
    public override void StateExit() { }

    private void Move(Vector2 _direction)
    {
        _direction.Normalize();
        Vector3 motion = new Vector3(_direction.x, 0f, _direction.y);
        _stateMachine.Player.Move(_stateMachine.Player.transform.position + motion * (_stateMachine.Player.Configuration.speed * Time.deltaTime));
    }
}