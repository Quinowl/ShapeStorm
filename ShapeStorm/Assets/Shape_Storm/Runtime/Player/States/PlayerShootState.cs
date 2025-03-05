using UnityEngine;

public class PlayerShootState : PlayerMovementState {
    [SerializeField] private Transform shootPoint;
    public override void CheckTransitions() {
        if (stateMachine.Player.ShootInputReleased) {
            stateMachine.SetState(stateMachine.Player.MoveInput == Vector2.zero ? typeof(PlayerIdleState) : typeof(PlayerMovementState));
        }
    }
}