using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

/*===============================================================
Product:    Action 2D Platformer	
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       13-03-2022 14:54:05
================================================================*/
namespace DWG.AI {

    public class PatrolPath : MonoBehaviour {
        [SerializeField]
        private List<Transform> patrolPoints = new List<Transform>();
        public int Length => patrolPoints.Count;
        
        [Header("Gizmo Parameters")]
        public Color pointColor = Color.blue;

        public float pointSize = 1;
        public Color lineColor = Color.magenta;
        public bool showGizmo = true;
        
        public struct PathPoint {
            public int Index;
            public Vector2 Position;
        }   

        public PathPoint GetClosestPathPoint(Vector3 agentPosition) {
            var result = patrolPoints.Select((point, index) => {
                    Vector3 position;
                    return new {
                        Index = index, Position = (Vector2) (position = point.position),
                        Distance = Vector2.Distance(agentPosition, position)
                    };
                })
                .Aggregate((p1, p2) => p1.Distance < p2.Distance ? p1 : p2);
            return new PathPoint { Index = result.Index, Position = result.Position };
        }

        public PathPoint GetNextPathPoint(int index) {
            var newIndex = index + 1 >= patrolPoints.Count ? 0 : index + 1;
            return new PathPoint {Index = newIndex, Position = patrolPoints[newIndex].position};
        }

        private void OnDrawGizmos() {
            if(!showGizmo || patrolPoints.Count == 0) return;
            for (var i = patrolPoints.Count - 1; i >= 0; i--) {
                if(patrolPoints[i]  == null) return;
                Gizmos.color = pointColor;
                Gizmos.DrawSphere(patrolPoints[i].position, pointSize);
                if (patrolPoints.Count == 1 || i == 0) return;

                Gizmos.color = lineColor;
                Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[i-1].position);
                if (patrolPoints.Count > 2 && i == patrolPoints.Count - 1) {
                    Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[0].position);
                }
            }
            
        }
    }
}
