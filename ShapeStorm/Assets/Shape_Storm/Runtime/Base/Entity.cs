using UnityEngine;

public abstract class Entity : MonoBehaviour {
    protected virtual void OnEnable() {
        PlayingState.OnUpdate += UpdateStep;
        PlayingState.OnLateUpdate += LateUpdateStep;
        PlayingState.OnFixed += FixedUpdateStep;
    }
    protected virtual void Awake() { }
    protected virtual void Start() { }
    protected virtual void OnDisable() {
        PlayingState.OnUpdate -= UpdateStep;
        PlayingState.OnLateUpdate -= LateUpdateStep;
        PlayingState.OnFixed -= FixedUpdateStep;
    }
    protected virtual void UpdateStep() { }
    protected virtual void LateUpdateStep() { }
    protected virtual void FixedUpdateStep() { }
}