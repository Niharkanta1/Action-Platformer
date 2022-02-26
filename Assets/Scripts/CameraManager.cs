using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/*===============================================================
Product:    Action 2D Platformer	
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       26-02-2022 13:12:30
================================================================*/
namespace DWG.Camera {

    public class CameraManager : MonoBehaviour {
        public CinemachineVirtualCamera cm_camera;

        private void Awake() {
            if (cm_camera == null) {
                cm_camera = FindObjectOfType<CinemachineVirtualCamera>();
            }
        }

        public void SetCameraTarget(Transform playerTransform) {
            cm_camera.LookAt = playerTransform;
            cm_camera.Follow = playerTransform;
        }
    }
}
