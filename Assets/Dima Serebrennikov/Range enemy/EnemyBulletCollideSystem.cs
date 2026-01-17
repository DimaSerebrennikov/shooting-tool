using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public sealed class EnemyBulletCollideSystem : MonoBehaviour {
        [SerializeField] List<Transform> _targets;
        [SerializeField] SplashSystemBehaviour _splashAsset;
        [SerializeField] EnemyBulletState _stateAsset;
        void Awake() {
            _splashAsset = TheUnityObject.InstanceFromAsset(_splashAsset);
            _stateAsset = TheUnityObject.InstanceFromAsset(_stateAsset);
        }
        public void Collide() {
            List<EnemyBulletCollision> onCollision = new();
            for (int k = 0; k < _targets.Count; k++) {
                Transform target = _targets[k];
                for (int i = 0; i < _stateAsset.Views.Count; i++) {
                    EnemyBulletCollision view = _stateAsset.Views[i];
                    for (int j = 0; j < view.Collisions.Count; j++) {
                        Transform collision = view.Collisions[j];
                        if (collision != target) {
                            continue;
                        }
                        Vector3 direction = view.transform.position - collision.position;
                        _splashAsset.Create(view.transform.position, direction, Color.blue);
                        onCollision.Add(view);
                        break;
                    }
                }
            }
            Remove(onCollision);
        }
        void Remove(List<EnemyBulletCollision> list) {
            for (int i = list.Count - 1; i >= 0; i--) {
                int index = _stateAsset.Views.IndexOf(list[i]);
                if (index == -1) {
                    continue;
                }
                Destroy(_stateAsset.Views[index].gameObject);
                _stateAsset.Views.RemoveAt(index);
                _stateAsset.Timers.RemoveAt(index);
            }
        }
    }
}