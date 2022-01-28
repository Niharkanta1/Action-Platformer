using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Agent : MonoBehaviour {

    public AgentDataSO agentData;
    public Rigidbody2D rb;
    public PlayerInput agentInput;
    public AgentAnimations animationManager;
    public AgentRenderer agentRenderer;
    public GroundDetector groundDetector;
    public ClimbingDetector climbingDetector;

    public State currentState = null, previousState = null;
    public State idleState;

    [Header("State debugging:")] public string stateName = "";
    [field: SerializeField]
    private UnityEvent onRespawnRequired { get; set; }

    private void Awake() {
        agentInput = GetComponentInParent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        animationManager = GetComponentInChildren<AgentAnimations>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        climbingDetector = GetComponentInChildren<ClimbingDetector>();

        State[] states = GetComponentsInChildren<State>();
        foreach (var varState in states) {
            varState.Initialize(this);
        }
    }

    private void Start() {
        agentInput.OnMovement += agentRenderer.FaceDirection;
        TransitionToState(idleState);
    }

    private void Update() {
        currentState.StateUpdate();
    }

    private void FixedUpdate() {
        groundDetector.CheckIfGrounded();
        currentState.StateFixedUpdate();
    }

    public void TransitionToState(State newState) {
        if (newState == null) {
            return;
        }
        if (currentState != null) {
            currentState.Exit();
        }

        previousState = currentState;
        currentState = newState;
        currentState.Enter();
        DisplayState();
    }

    private void DisplayState() {
        if (previousState == null || previousState.GetType() != currentState.GetType()) {
            stateName = currentState.GetType().ToString();
        }
    }

    public void AgentDied() {
        Debug.Log("Player Died!");
        onRespawnRequired?.Invoke();
    }
}
