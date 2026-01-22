using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    class EnemyBulletViewSystem : MonoBehaviour {
        [SerializeField] EnemyBulletSystemContext _contextAsset;
        [SerializeField] EnemyBulletCollision _bulletPrefab;
        [SerializeField] EnemyBulletState _stateAsset;
        ParticleSystem _shootingVfx;
        [SerializeField] ParticleSystemOwner _owner;
        void Awake() {
            _contextAsset = TheUnityObject.InstanceFromAsset(_contextAsset);
            _stateAsset = TheUnityObject.InstanceFromAsset(_stateAsset);
            _owner = TheUnityObject.InstanceFromAsset(_owner);
            _shootingVfx = _owner.ParticleSystem;
        }
        public void View() {
            for (int i = 0; i < _contextAsset.AddedBullets.Count; i++) {
                EnemyBullet bullet = _contextAsset.AddedBullets[i];
                EnemyBulletCollision view = Instantiate(_bulletPrefab, bullet.Position, bullet.Rotation);
                _stateAsset.Views.Add(view);
                _stateAsset.Timers.Add(0f);
                _shootingVfx.Play();
            }
            _contextAsset.AddedBullets.Clear();
        }
    }
}
