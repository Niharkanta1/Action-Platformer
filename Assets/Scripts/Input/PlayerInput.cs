using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour {
    
    [field: SerializeField] 
    public Vector2 MovementVector { get; private set; }

    public event Action OnAttack, OnJumpPressed, OnJumpReleased, OnWeaponChange;
    public event Action<Vector2> OnMovement;
    public KeyCode jumpKey, attackKey, menuKey;
    public UnityEvent onMenuKeyPressed;

    private void Update() {
        if (Time.timeScale > 0) {
            GetMovementInput();
            GetJumpInput();
            GetAttackInput();
            GetWeaponSwapInput();
        }

        GetMenuInput();
    }

    private void GetMenuInput() {
        if (Input.GetKeyDown(menuKey)) {
            OnWeaponChange?.Invoke();
        }
    }
    
    private void GetWeaponSwapInput() {
        if (Input.GetKeyDown(KeyCode.E)) {
            onMenuKeyPressed?.Invoke();
        }
    }

    private void GetAttackInput() {
        if (Input.GetKeyDown(attackKey)) {
            OnAttack?.Invoke();
        }
    }

    private void GetJumpInput() {
        if (Input.GetKeyDown(jumpKey)) {
            OnJumpPressed?.Invoke();
        }
        if (Input.GetKeyUp(jumpKey)) {
            OnJumpReleased?.Invoke();
        }
    }

    private void GetMovementInput() {
        MovementVector = GetMovementVector();
        OnMovement?.Invoke(MovementVector);
    }

    protected Vector2 GetMovementVector() {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
