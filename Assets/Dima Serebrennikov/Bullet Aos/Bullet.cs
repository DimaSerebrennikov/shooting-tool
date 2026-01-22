// BulletManager.csC:\Feeble snow\Assets\Serebrennikov\Bullet Aos\BulletManager.csBulletManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class Bullet : MonoBehaviour {
        [SerializeField] EnemyHealthContext _enemyHealthContextAsset;
        [SerializeField] TransformConfiguration _barrelAsset;
        [SerializeField] float _speed;
        [SerializeField] SplashSystemBehaviour _splashSystem;
        [SerializeField] BulletContext _bulletContext;
        [SerializeField] CollisionWithFigureContext _collisionContextAsset;
        [SerializeField] BulletMask _mask;
        MovingForward _forward;
        BarrelHandler _barrelHandler;
        BulletTimer _timer;
        BulletDestruction _destruction;
        BulletCollisionSystem _collisionSystem;
        void Awake() {
            _bulletContext = TheUnityObject.InstanceFromAsset(_bulletContext);
            _splashSystem = TheUnityObject.InstanceFromAsset(_splashSystem);
            _enemyHealthContextAsset = TheUnityObject.InstanceFromAsset(_enemyHealthContextAsset);
            _barrelAsset = TheUnityObject.InstanceFromAsset(_barrelAsset);
            _mask = TheUnityObject.InstanceFromAsset(_mask);
            _collisionSystem = new BulletCollisionSystem(_enemyHealthContextAsset);
            BulletData data = new(transform, _speed);
            _forward = new MovingForward(data);
            _barrelHandler = new BarrelHandler(_barrelAsset.Barrel, data);
            _timer = new BulletTimer(1f, data);
            _destruction = new BulletDestruction(data, gameObject);
            _collisionContextAsset = TheUnityObject.InstanceFromAsset(_collisionContextAsset); /*можно вывести в компонент*/
            _collisionContextAsset.List.Add(transform);
        }
        public void Start() {
            _barrelHandler.Start();
        }
        public void Update() {
            _forward.Update();
            _timer.Update(Time.deltaTime);
            _destruction.Update();
        }
        void OnTriggerEnter(Collider other) {
            for (int i = 0; i < _mask.Mask.Count; i++) {
                GameObject n = _mask.Mask[i];
                if (other.gameObject == n) {
                    _bulletContext.OnTrigger.Invoke(other.gameObject);
                    _collisionSystem.Collide(other.gameObject);
                    _splashSystem.Create(transform.position, -transform.forward, Color.red);
                    _destruction.Destroy();
                }
            }
        }
    }
}
