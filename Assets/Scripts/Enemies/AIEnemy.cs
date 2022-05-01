using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-01-2022 19:35:59
================================================================*/
namespace DWG.AI {

    public abstract class AIEnemy : MonoBehaviour, IAgentInput {
        
        public Vector2 MovementVector { get; set; }
        public event Action OnAttack;
        public event Action OnJumpPressed;
        public event Action OnJumpReleased;
        public event Action<Vector2> OnMovement;
        public event Action OnWeaponChange;

        public void CallOnAttack() {
            OnAttack?.Invoke();
        }

        public void CallOnJumpPressed() {
            OnJumpPressed?.Invoke();
        }

        public void CallOnJumpReleased() {
            OnJumpReleased?.Invoke();
        }

        public void CallOnMovement(Vector2 input) {
            OnMovement?.Invoke(input);
        }

        public void CallOnWeaponChange() {
            OnWeaponChange?.Invoke();
        }

        public void CallAttack() {
            OnAttack?.Invoke();
        }
    }
}
