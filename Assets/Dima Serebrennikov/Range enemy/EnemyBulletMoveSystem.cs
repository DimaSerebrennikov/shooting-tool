using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public sealed class EnemyBulletMoveSystem : MonoBehaviour {
        [SerializeField] float _speed = 3f;
        [SerializeField] float _gravityRotationSpeed = 5f;
        [SerializeField] EnemyBulletState _stateAsset;
        void Awake() {
            _stateAsset = TheUnityObject.InstanceFromAsset(_stateAsset);
        }
        public void Move() {
            for (int i = 0; i < _stateAsset.Views.Count; i++) {
                Transform transform = _stateAsset.Views[i].transform;
                transform.Rotate(_gravityRotationSpeed * Time.deltaTime, 0f, 0f, Space.Self);
                transform.position += transform.forward * (_speed * Time.deltaTime);
            }
        }
    }
}
