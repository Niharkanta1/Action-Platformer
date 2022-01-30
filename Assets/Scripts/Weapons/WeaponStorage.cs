using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       29-01-2022 00:03:27
================================================================*/
namespace WeaponSystem {
    
    public class WeaponStorage {

        private List<WeaponData> _weaponDataList = new List<WeaponData>();
        private int _currentWeaponIndex = -1;
        public int WeaponCount => _weaponDataList.Count;

        public WeaponData GetCurrentWeapon() {
            return _currentWeaponIndex == -1 ? null : _weaponDataList[_currentWeaponIndex];
        }

        // TODO: need to revisit
        public WeaponData SwapWeapon() {
            if (_currentWeaponIndex == -1) return null;
            _currentWeaponIndex++;
            if (_currentWeaponIndex >= _weaponDataList.Count)
                _currentWeaponIndex = 0;
            return _weaponDataList[_currentWeaponIndex];
        }

        public bool AddWeaponData(WeaponData weaponData) {
            if (_weaponDataList.Contains(weaponData)) return false;
            _weaponDataList.Add(weaponData);
            _currentWeaponIndex = _weaponDataList.Count - 1;
            return true;
        }

        public List<string> GetPlayerWeaponNames() {
            return _weaponDataList.Select(weapon => weapon.name).ToList();
        }
    }
    
    
}

