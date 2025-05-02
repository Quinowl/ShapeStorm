using UnityEngine;

public class GameManager : MonoBehaviour 
{
    
    private IGameState _currentGameState;

    public static GameManager Instance { get; private set; }

    private void Awake() 
    {
        if (!Instance) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        SetGameState(new PlayingState());
    }

    private void Update() 
    {
        _currentGameState?.GameStateUpdate();
    }

    void LateUpdate() 
    {
        _currentGameState?.GameStateLateUpdate();
    }

    private void FixedUpdate() 
    {
        _currentGameState?.GameStateFixedUpdate();
    }

    public void SetGameState(IGameState _nextGameState) 
    {
        if (_nextGameState == _currentGameState) return;
        _currentGameState?.GameStateExit();
        _currentGameState = _nextGameState;
        _currentGameState?.GameStateEnter();
    }
}