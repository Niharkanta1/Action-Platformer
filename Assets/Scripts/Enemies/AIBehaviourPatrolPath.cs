using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer	
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       13-03-2022 15:33:20
================================================================*/
namespace DWG.AI {

    public class AIBehaviourPatrolPath : AIBehaviour {
        [SerializeField]
        public PatrolPath patrolPath;
        [SerializeField]
        [Range(0.1f, 1)] private float arriveDistance = 1;
        [SerializeField]
        public float waitTime = 0.5f;
        [SerializeField]
        private bool isWaiting = false;
        [SerializeField]
        private Vector2 currentPatrolTarget = Vector2.zero;
        
        [SerializeField] private Transform agent;

        private bool _isInitialized = false;
        private int _currentIndex = -1;
        
        public override void PerformAction(AIEnemy enemyAI) {
            if (isWaiting) return;
            if (patrolPath.Length < 2) return;
            if (!_isInitialized) {
                var currentPathPoint = patrolPath.GetClosestPathPoint(agent.position);
                this._currentIndex = currentPathPoint.Index;
                this.currentPatrolTarget = currentPathPoint.Position;
                _isInitialized = true;
            }

            if (Vector2.Distance(agent.position, currentPatrolTarget) < arriveDistance) {
                isWaiting = true;
                enemyAI.MovementVector = Vector2.zero;
                StartCoroutine(WaitCoroutine());
                return;
            }

            Vector2 directionToFollow = currentPatrolTarget - (Vector2) agent.position;
            enemyAI.CallOnMovement(directionToFollow.normalized);
            enemyAI.MovementVector = directionToFollow.normalized;
        }

        private IEnumerator WaitCoroutine() {
            yield return new WaitForSeconds(waitTime);
            var nextPathPoint = patrolPath.GetNextPathPoint(_currentIndex);
            currentPatrolTarget = nextPathPoint.Position;
            _currentIndex = nextPathPoint.Index;
            isWaiting = false;
        }
    }
}
