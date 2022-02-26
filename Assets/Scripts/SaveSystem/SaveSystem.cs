using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       13-02-2022 23:37:23
================================================================*/
namespace DWG.Levels {

    public static class SaveSystem {
        private static string _pointKey = "Points";
        private static string _playerWeaponKey = "PlayersWeapons";
        private static string _levelKey = "LevelKey";
        private static string _saveDataKey = "saveDataKey";

        public static void SaveGameData(int levelIndexToSave) {
            SaveLevel(levelIndexToSave);
            PlayerPrefs.SetInt(_saveDataKey, 1);
        }

        private static void SaveLevel(int levelIndexToSave) {
            PlayerPrefs.SetInt(_levelKey, levelIndexToSave);
        }

        public static int LoadLevelIndex() {
            if (IsSaveDataPresent()) {
                return PlayerPrefs.GetInt(_levelKey);
            }

            return -1;
        }

        private static bool IsSaveDataPresent() {
            return PlayerPrefs.GetInt(_saveDataKey) == 1;
        }

        public static void SaveWeapons(List<string> weaponNames) {
            string data = JsonUtility.ToJson(new PlayerWeapons { playerWeapons = weaponNames });
            PlayerPrefs.SetString(_playerWeaponKey, data);
        }

        public static List<string> LoadWeapons() {
            if (!IsSaveDataPresent()) return null;
            string data = PlayerPrefs.GetString(_playerWeaponKey);
            return data.Length > 0 ? JsonUtility.FromJson<PlayerWeapons>(data).playerWeapons : null;
        }

        public static void SavePoints(int amount) {
            PlayerPrefs.SetInt(_pointKey, amount);
        }

        public static int LoadPoints() {
            return PlayerPrefs.GetInt(_pointKey);
        }

        public static void ResetSaveData() {
            PlayerPrefs.DeleteKey(_pointKey);
            PlayerPrefs.DeleteKey(_playerWeaponKey);
            PlayerPrefs.DeleteKey(_levelKey);
            PlayerPrefs.DeleteKey(_saveDataKey);
        }
        
    }

    public struct PlayerWeapons {
        public List<string> playerWeapons;
    }
}
