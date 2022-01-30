using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using WeaponSystem;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       29-01-2022 21:42:20
================================================================*/

public class Damageable : MonoBehaviour, IHittable {    

    [SerializeField] private int maxHealth;
    [SerializeField] private int _currentHealth;

    public UnityEvent OnGetHit;
    public UnityEvent OnDie;
    public UnityEvent OnAddHealth;
    public UnityEvent<int> OnHealthValueChange;
    public UnityEvent<int> OnInitializeMaxHealth;

    public int CurrentHealth {
        get => _currentHealth;
        set {
            _currentHealth = value;
            OnHealthValueChange?.Invoke(_currentHealth);
        }
    }
    
    public void GetHit(GameObject agentGameObject, int weaponDamage) {
        GetHit(weaponDamage);
    }   

    public void GetHit(int weaponDamage) {
        CurrentHealth -= weaponDamage;
        if (_currentHealth <= 0) {
            OnDie?.Invoke();
        } else {
            OnGetHit?.Invoke();
        }
    }

    public void AddHealth(int val) {
        CurrentHealth = Mathf.Clamp(CurrentHealth + val, 0, maxHealth);
        OnAddHealth?.Invoke();
    }

    public void Initialize(int health) {
        maxHealth = health;
        OnInitializeMaxHealth?.Invoke(maxHealth);
        CurrentHealth = maxHealth;
    }
}
