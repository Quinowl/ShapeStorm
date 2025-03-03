using System;

public class PlayingState : IGameState {
    public static Action OnUpdate;
    public static Action OnFixed;

    public void GameStateEnter() { }

    public void GameStateExit() { }

    public void GameStateFixedUpdate() => OnFixed?.Invoke();

    public void GameStateUpdate() => OnUpdate?.Invoke();
}