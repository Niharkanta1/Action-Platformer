using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-04-2022 22:03:20
================================================*/

namespace DWG.Camera {

    public class CmCameraConfinerUtil : MonoBehaviour {
        public PolygonCollider2D originalCameraConfiner;
        public PolygonCollider2D cameraConfiner;
        public CinemachineConfiner cm_Confiner;

        public void SetConfiner() {
            cm_Confiner.m_BoundingShape2D = cameraConfiner;
        }

        public void ResetConfiner() {
            cm_Confiner.m_BoundingShape2D = originalCameraConfiner;
        }
    }
}