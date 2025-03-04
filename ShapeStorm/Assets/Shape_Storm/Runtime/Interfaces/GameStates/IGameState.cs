public interface IGameState {
    void GameStateEnter();
    void GameStateUpdate();
    void GameStateLateUpdate();
    void GameStateFixedUpdate();
    void GameStateExit();
}