using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

/*===============================================================
Product:    Udemy 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       29-01-2022 19:52:50
================================================================*/

public class StateFactory : MonoBehaviour {

    [SerializeField] private State idleState, moveState, fallState, climbState, jumpState, attackState;

    public State GetState(StateType stateType) => stateType switch {
        StateType.Idle => idleState,
        StateType.Move => moveState,
        StateType.Climb => climbState,
        StateType.Jump => jumpState,
        StateType.Fall => fallState,
        StateType.Attack => attackState,
        _ => throw new ArgumentOutOfRangeException(nameof(stateType), stateType, $"State Type Not Found::{stateType}")
    };

    public void InitializeStates(Agent agent) {
        State[] states = GetComponentsInChildren<State>();
        foreach (var varState in states) {
            varState.Initialize(agent);
        }
    }
}
