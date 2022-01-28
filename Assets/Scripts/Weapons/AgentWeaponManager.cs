using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*===============================================================
Product:    Udemy 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       29-01-2022 00:03:10
================================================================*/

namespace WeaponSystem {
    
    public class AgentWeaponManager : MonoBehaviour {

        private SpriteRenderer _spriteRenderer;
        private WeaponStorage _weaponStorage;

        public UnityEvent<Sprite> onWeaponSwap;
        public UnityEvent onMultipleWeapons;
        public UnityEvent onWeaponPickup;

        private void Awake() {
            _weaponStorage = new WeaponStorage();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            ToggleWeaponVisibility(false);
        }

        private void ToggleWeaponVisibility(bool val) {
            if (val) {
                SwapWeaponSprite(GetCurrentWeapon().weaponSprite);
            }
        }

        public WeaponData GetCurrentWeapon() {
            return _weaponStorage.GetCurrentWeapon();
        }

        private void SwapWeaponSprite(Sprite weaponSprite) {
            _spriteRenderer.sprite = weaponSprite;
            onWeaponSwap?.Invoke(weaponSprite);
        }

        public void SwapWeapon() {
            if (_weaponStorage.WeaponCount <= 0) return;
            SwapWeaponSprite(_weaponStorage.SwapWeapon().weaponSprite);
        }

        public void AddWeaponData(WeaponData weaponData) {
            if(_weaponStorage.AddWeaponData(weaponData) == false)
                return;
            if (_weaponStorage.WeaponCount == 2) {
                onMultipleWeapons?.Invoke();
            }
            SwapWeaponSprite(weaponData.weaponSprite);
        }

        public void PickUpWeapon(WeaponData weaponData) {
            AddWeaponData(weaponData);
            onWeaponPickup?.Invoke();
        }

        public bool CanIUseWeapon(bool isGrounded) {
            return _weaponStorage.WeaponCount > 0 && _weaponStorage.GetCurrentWeapon().CanBeUsed(isGrounded);
        }

        public List<string> GetPlayerWeaponNames() {
            return _weaponStorage.GetPlayerWeaponNames();
        }
    }
}
