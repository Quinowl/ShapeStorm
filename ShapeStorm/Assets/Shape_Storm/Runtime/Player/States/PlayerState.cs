using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    protected PlayerStateMachine _stateMachine;
    public void Configure(PlayerStateMachine _stateMachine)
    {
        this._stateMachine = _stateMachine;
    }
    public abstract void StateInputs();
    public abstract void StateEnter();
    public abstract void StateStep();
    public abstract void CheckTransitions();
    public abstract void StateLateStep();
    public abstract void StatePhysicsStep();
    public abstract void StateExit();
}