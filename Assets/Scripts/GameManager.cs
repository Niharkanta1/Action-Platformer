using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DWG.Camera;
using DWG.Levels;
using RespawnSystem;
using UnityEditor;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer	
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       26-02-2022 13:09:19
================================================================*/

public class GameManager : MonoBehaviour {
    [SerializeField]
    private CameraManager cameraManager;
    [SerializeField]
    private RespawnPointManager respawnPointManager;
    [SerializeField]
    private Agent player;
    private LevelManagement _levelManagement;

    private void Awake() {
        if (cameraManager == null) {
            cameraManager = FindObjectOfType<CameraManager>();
        }

        if (respawnPointManager == null) {
            respawnPointManager = FindObjectOfType<RespawnPointManager>();
        }

        if (player == null) {
            player = FindObjectOfType<PlayerInput>().GetComponentInChildren<Agent>();
        }

        _levelManagement = FindObjectOfType<LevelManagement>();
    }

    private void Start() {
        LoadData();
        player.gameObject.SetActive(false);
        respawnPointManager.Respawn(player.gameObject);
        cameraManager.SetCameraTarget(player.transform);
    }

    private void LoadData() {
        IEnumerable<ISaveData> saveDataScripts = FindObjectsOfType<MonoBehaviour>().OfType<ISaveData>();
        foreach (ISaveData item in saveDataScripts) {
            item.LoadData();
        }
    }

    public void SaveGameData() {
        IEnumerable<ISaveData> saveDataScripts = FindObjectsOfType<MonoBehaviour>().OfType<ISaveData>();
        foreach (ISaveData item in saveDataScripts) {
            item.SaveData();
        }
        SaveSystem.SaveGameData(_levelManagement.GetNextLevelIndex());
    }
}
