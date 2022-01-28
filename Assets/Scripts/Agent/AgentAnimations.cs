using System;
using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine;
using UnityEngine.Events;

public class AgentAnimations : MonoBehaviour {
    private Animator _animator;
    
    public UnityEvent onAnimationAction;
    public UnityEvent onAnimationEnd;

    private void Awake() {
        _animator = GetComponent<Animator>();
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
            default:
                Debug.LogError($"No Animation found:: {nameof(animationType)}");
                throw new NoAnimationFoundException(nameof(animationType), animationType, null);
        }
    }

    private void Play(string animName) {
        _animator.Play(animName, -1, 0f);
    }
    
    public void StartAnimation() {
        _animator.enabled = true;
    }

    public void StopAnimation() {
        _animator.enabled = false;
    }

    public void ResetEvents() {
        onAnimationAction.RemoveAllListeners();
        onAnimationEnd.RemoveAllListeners();
    }

    public void InvokeAnimationAction() {
        onAnimationAction?.Invoke();
    }

    public void InvokeAnimationEnd() {
        onAnimationEnd?.Invoke();
    }
}