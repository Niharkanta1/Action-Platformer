using System;
using System.Collections;
using System.Collections.Generic;
using DWG.Levels;
using UnityEngine;
using WeaponSystem;

/*===============================================================
Product:    Action 2D Platformer	
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       26-02-2022 15:53:47
================================================================*/

public class Player : MonoBehaviour, ISaveData {
    [SerializeField]
    private AgentWeaponManager playerWeapons;
    private WeaponManager _weaponManager;

    private void Awake() {
        _weaponManager = FindObjectOfType<WeaponManager>();
    }

    public void SaveData() {
        List<string> weaponNamess = playerWeapons.GetPlayerWeaponNames();
        if(weaponNamess != null && weaponNamess.Count > 0)
            SaveSystem.SaveWeapons(weaponNamess);
    }

    public void LoadData() {
        List<string> weaponNames = SaveSystem.LoadWeapons();
        if (weaponNames != null) {
            foreach (string weaponName in weaponNames) {
                //Debug.Log("Loading weapon: " + weaponName);
                WeaponData weapon = _weaponManager.GetWeaponWithName(weaponName);
                playerWeapons.AddWeaponData(weapon);
            }
        }
        else {
            Debug.Log("No weapon data to load.");
        }
    }
}
