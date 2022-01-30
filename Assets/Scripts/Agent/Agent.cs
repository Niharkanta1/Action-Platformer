using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Utils;
using WeaponSystem;

public class Agent : MonoBehaviour {

    public AgentDataSO agentData;
    public Rigidbody2D rb;
    public IAgentInput AgentInput;
    public AgentAnimations animationManager;
    public AgentRenderer agentRenderer;
    public GroundDetector groundDetector;
    public ClimbingDetector climbingDetector;

    public State currentState = null, previousState = null;

    [HideInInspector]
    public AgentWeaponManager agentWeapon;

    public StateFactory stateFactory;

    private Damageable _damageable;
    
    [Header("State debugging:")] public string stateName = "";
    [field: SerializeField]
    private UnityEvent OnRespawnRequired { get; set; }
    [field: SerializeField]
    public UnityEvent OnAgentDie { get; set; }

    private void Awake() {
        AgentInput = GetComponentInParent<IAgentInput>();
        rb = GetComponent<Rigidbody2D>();
        animationManager = GetComponentInChildren<AgentAnimations>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        climbingDetector = GetComponentInChildren<ClimbingDetector>();
        agentWeapon = GetComponentInChildren<AgentWeaponManager>();
        stateFactory = GetComponentInChildren<StateFactory>();
        stateFactory.InitializeStates(this);

        _damageable = GetComponent<Damageable>();
    }

    private void Start() {
        AgentInput.OnMovement += agentRenderer.FaceDirection;
        InitializeAgent();
    }

    private void InitializeAgent() {
        TransitionToState(stateFactory.GetState(StateType.Idle));
        _damageable.Initialize(agentData.health);
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
        if (_damageable.CurrentHealth > 0) {
            rb.velocity = Vector2.zero; 
            OnRespawnRequired?.Invoke();
        } else {
            currentState.Die();
        }
    }

    public void GetHit() {
        currentState.GetHit();
    }
}
