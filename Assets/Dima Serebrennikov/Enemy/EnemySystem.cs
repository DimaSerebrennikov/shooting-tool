using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class EnemySystem : MonoBehaviour {
        [SerializeField] Transform _targetPacked;
        [SerializeField] float _speed;
        [SerializeField] PlayerHealthContext _playerHealthPacked;
        PlayerHealthContext _playerHealth;
        Transform _target;
        MoveToTarget _moving;
        EnemyMovingSystem _movingSystem;
        void Awake() {
            _playerHealth = TheUnityObject.InstanceFromAsset(_playerHealthPacked);
            _target = TheUnityObject.InstanceFromAsset(_targetPacked);
        }
        void FixedUpdate() {
            _movingSystem.Update(Time.fixedDeltaTime);
        }
    }
}
