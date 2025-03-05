using UnityEngine;

public class PlayerShootState : PlayerMovementState {
    [SerializeField] private Transform shootPoint;
    public override void CheckTransitions() {
        // if (stateMachine.Player.InputHandler.ShootReleased) {
        //     stateMachine.SetState(stateMachine.Player.InputHandler.MoveInput == Vector2.zero ? typeof(PlayerIdleState) : typeof(PlayerMovementState));
        // }
    }
}