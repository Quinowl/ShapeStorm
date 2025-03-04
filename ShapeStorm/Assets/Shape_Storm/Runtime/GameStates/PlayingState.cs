using System;

public class PlayingState : IGameState {
    public static Action OnUpdate;
    public static Action OnLateUpdate;
    public static Action OnFixed;

    public void GameStateEnter() { }
    public void GameStateExit() { }
    public void GameStateFixedUpdate() => OnFixed?.Invoke();
    public void GameStateLateUpdate() => OnLateUpdate?.Invoke();
    public void GameStateUpdate() => OnUpdate?.Invoke();
}