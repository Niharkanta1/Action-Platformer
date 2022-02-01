using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       02-02-2022 01:06:28
================================================================*/

public class WeaponUI : MonoBehaviour {

    [SerializeField] private Image weaponSprite;
    [SerializeField] private GameObject weaponSwapTip;

    public UnityEvent onSwapWeaponEvent, onToggleWeaponTipUI;

    private void Start() {
        weaponSprite.enabled = false;
        weaponSprite.sprite = null;
        weaponSwapTip.SetActive(false);
    }

    public void SetWeaponImage(Sprite sprite) {
        if(this.weaponSprite.sprite == sprite) return;
        this.weaponSprite.enabled = true;
        this.weaponSprite.sprite = sprite;
        onSwapWeaponEvent?.Invoke();
    }

    public void ToggleWeaponTip(bool value) {
        weaponSwapTip.SetActive(value);
        if(value) onToggleWeaponTipUI?.Invoke();
    }
}
