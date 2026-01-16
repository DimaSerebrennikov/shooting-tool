using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class Enemy : MonoBehaviour, IHealth {
        [SerializeField] Transform _targetPacked;
        [SerializeField] EnemyConfiguration _configuration;
        [SerializeField] PlayerHealthContext _playerHealthPacked;
        [SerializeField] EnemyHealthContext _enemyHealthContextPacked;
        [SerializeField] Rigidbody _rb;
        EnemyHealthContext _enemyHealthContext;
        PlayerHealthContext _playerHealth;
        Transform _target;
        [SerializeField] LimitedValueContext _health;
        void Awake() {
            _configuration = TheUnityObject.InstanceFromAsset(_configuration);
            _enemyHealthContext = TheUnityObject.InstanceFromAsset(_enemyHealthContextPacked);
            _playerHealth = TheUnityObject.InstanceFromAsset(_playerHealthPacked);
            _target = TheUnityObject.InstanceFromAsset(_targetPacked);
            _health.Value = 5f;
            _health.OnBottom += OnBottomHealth;
            _enemyHealthContext.EnemyHealth.Add(gameObject, this);
        }
        void OnBottomHealth() {
            _enemyHealthContext.EnemyHealth.Remove(gameObject);
            Destroy(gameObject);
        }
        void FixedUpdate() {
            Vector3 direction = (_target.position - transform.position).normalized;
            Vector3 torque = Vector3.Cross(Vector3.up, direction) * _configuration.Speed;
            _rb.AddTorque(torque, ForceMode.Acceleration);
        }
        void OnCollisionStay(Collision other) {
            if (other.transform == _target) {
                _playerHealth.Deal(1f);
            }
        }
        public void Deal(float value) {
            _health.Value -= value;
        }
    }
}
