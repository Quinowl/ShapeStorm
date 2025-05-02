using System;
using System.Linq;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour 
{

    [SerializeField] private PlayerState[] states;

    public PlayerState CurrentState { get; private set; }
    public Player Player { get; private set; }

    public void Initialize() 
    {
        if (states == null || states.Length == 0) 
        {
            Debug.LogWarning("No states assigned.");
            return;
        }
        foreach (var state in states) state.Configure(this);
        SetState(states[0].GetType());
    }

    public void Configure(Player _player) 
    {
        Player = _player;
    }

    public void Step() 
    {
        if (CurrentState == null) return;
        CurrentState.StateInputs();
        CurrentState.CheckTransitions();
        CurrentState.StateStep();
    }

    public void PhysicsStep() 
    {
        if (CurrentState == null) return;
        CurrentState.StatePhysicsStep();
    }

    public void LateStep() 
    {
        if (CurrentState == null) return;
        CurrentState.StateLateStep();
    }

    public void SetState(Type _nextState) 
    {
        PlayerState nextState = states.FirstOrDefault(s => s.GetType() == _nextState);
        if (nextState == null || nextState == CurrentState) return;
        CurrentState?.StateExit();
        CurrentState = nextState;
        CurrentState?.StateEnter();
    }
}