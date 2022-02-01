using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       01-02-2022 22:45:30
================================================================*/
namespace WeaponSystem {
    
    public class ThrowableWeapon : MonoBehaviour {
        private Vector2 _startPosition = Vector2.zero;   
        private RangeWeaponData _data;
        private Vector2 _movementDirection;
        private Rigidbody2D _rb;
        private bool _isInitialized;
        private LayerMask _layerMask;
        
        [SerializeField]
        private Transform spriteTransform;
        [SerializeField]
        private float rotaionSpeed = 700;
       
        
        [Header("Collision Detection Data:")]
        
        [SerializeField] private Vector2 center = Vector2.zero;
        [SerializeField] [Range(0.1f, 2f)] private float radius = 1;
        [SerializeField] Color gizmoColor = Color.red;

        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
            if (spriteTransform == null) {
                spriteTransform = transform.GetChild(0);
            }
        }

        private void Start() {
            _startPosition = transform.position;
        }

        public void Initialize(RangeWeaponData weaponData, Vector2 direction, LayerMask mask) {
            _movementDirection = direction;
            _data = weaponData;
            _isInitialized = true;
            _rb.velocity = _movementDirection * _data.weaponThrowSpeed;
            _layerMask = mask;
        }

        private void Update() {
            if (!_isInitialized) return;
            Fly();
            DetectCollision();
            if (((Vector2) transform.position - _startPosition).magnitude >= _data.attackRange) {
                Destroy(gameObject);
            }
        }

        private void Fly() {
            spriteTransform.rotation *= Quaternion.Euler(0, 0, Time.deltaTime * rotaionSpeed * -_movementDirection.x);
        }

        private void DetectCollision() {
            Collider2D collision = Physics2D.OverlapCircle((Vector2) transform.position + center, radius, _layerMask);
            if (collision == null) return;
            foreach (var hittable in collision.GetComponents<IHittable>()) {
                hittable.GetHit(gameObject, _data.weaponDamage);
            }
            Destroy(gameObject);
        }

        private void OnDrawGizmos() {
            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(transform.position + (Vector3)center, radius);
        }
    }
}
