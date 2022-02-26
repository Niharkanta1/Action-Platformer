using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WeaponSystem;

/*===============================================================
Product:    Action 2D Platformer	
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       26-02-2022 15:44:56
================================================================*/

public class WeaponManager : MonoBehaviour {
    public List<WeaponData> weaponDatas;
    private Dictionary<string, WeaponData> weaponDictionary = new Dictionary<string, WeaponData>();

    private void Awake() {
        AddToDictionary(weaponDatas);
    }

    private void AddToDictionary(List<WeaponData> list) {
        foreach (var item in list.Where(item => !weaponDictionary.ContainsKey(item.weaponName))) {
            //Debug.Log("add to dict::"+ item.weaponName);
            weaponDictionary.Add(item.weaponName, item);
        }
       //Debug.Log("Weapon Dictionary::"+weaponDictionary.Count);
    }

    public WeaponData GetWeaponWithName(string weaponName) {
        //Debug.Log("Finding weapon from Dict::"+ weaponName);
        return weaponDictionary.ContainsKey(weaponName) ? weaponDictionary[weaponName] : null;
    }
}
