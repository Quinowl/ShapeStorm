using UnityEngine;

public class GameManager : MonoBehaviour {
    private IGameState currentGameState;

    public static GameManager Instance { get; private set; }

    private void Awake() {
        if (!Instance) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        SetGameState(new PlayingState());
    }

    private void Update() {
        currentGameState?.GameStateUpdate();
    }

    void LateUpdate() {
        currentGameState?.GameStateLateUpdate();
    }

    private void FixedUpdate() {
        currentGameState?.GameStateFixedUpdate();
    }

    public void SetGameState(IGameState _nextGameState) {
        if (_nextGameState == currentGameState) return;
        currentGameState?.GameStateExit();
        currentGameState = _nextGameState;
        currentGameState?.GameStateEnter();
    }
}