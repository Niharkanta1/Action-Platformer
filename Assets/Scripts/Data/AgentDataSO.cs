using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentData", menuName = "Agent/Data")]
public class AgentDataSO : ScriptableObject {
    [Header("Health")] [Space] public int health = 2;

    [Header("Movement data")]
    [Space] 
    public float acceleration = 50; 
    public float deAcceleration = 50;
    public float maxSpeed = 6;
    
    [Header("Jump data")]
    [Space]
    public float jumpForce = 12;
    public float lowJumpMultiplier = 2;
    public float gravityModifier = 0.5f;
    
    [Header("Climb data")]
    [Space]
    public float climbHorizontalSpeed = 1;
    public float climbVerticalSpeed = 3;
}
