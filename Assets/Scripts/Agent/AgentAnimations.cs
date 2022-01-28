using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimations : MonoBehaviour {
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(AnimationType animationType) {
        switch (animationType) {
            case AnimationType.Die:
                break;
            case AnimationType.Hit:
                break;
            case AnimationType.Idle:
                Play("idle");
                break;
            case AnimationType.Attack:
                break;
            case AnimationType.Run:
                Play("run");
                break;
            case AnimationType.Jump:
                Play("jump");
                break;
            case AnimationType.Fall:
                Play("fall");
                break;
            case AnimationType.Climb:
                Play("climb");
                break;
            case AnimationType.Land:
                break;
        }
    }

    public void Play(string name) {
        animator.Play(name, -1, 0f);
    }
    
    public void StartAnimation() {
        animator.enabled = true;
    }

    public void StopAnimation() {
        animator.enabled = false;
    }
}

public enum AnimationType {
    Die,
    Hit,
    Idle,
    Attack,
    Run,
    Jump,
    Fall,
    Climb,
    Land
}