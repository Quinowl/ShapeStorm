using System;
using UnityEngine;

public class Player : Entity {
    [SerializeField] private PlayerStateMachine stateMachine;
    protected override void Start() {
        base.Start();
        stateMachine.Configure(this);
        stateMachine.Initialize();
    }
}