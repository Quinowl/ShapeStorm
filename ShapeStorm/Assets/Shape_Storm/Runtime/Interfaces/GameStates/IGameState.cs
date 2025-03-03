public interface IGameState {
    void GameStateEnter();
    void GameStateUpdate();
    void GameStateFixedUpdate();
    void GameStateExit();
}