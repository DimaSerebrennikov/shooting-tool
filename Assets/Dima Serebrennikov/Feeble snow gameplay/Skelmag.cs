using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    
    public class Skelmag : MonoBehaviour, IHealth {
        [SerializeField] SkelmagConfiguration _configurationAsset;
        [SerializeField] Component _bulletPrefab;
        [SerializeField] SkelmagModelConfiguration modelAsset;
        [SerializeField] CollisionWithFigureContext _collisionContextAsset;
        SkelmagCore _coreSystem;
        SkelmagShootingData _shootingComponent;
        ExtendedHealth _extendedHealthSystem;
        void Awake() {
            _configurationAsset = TheUnityObject.InstanceFromAsset(_configurationAsset);
            modelAsset = TheUnityObject.InstanceFromAsset(modelAsset);
            _configurationAsset.Hands = TheUnityObject.InstanceFromAsset(_configurationAsset.Hands);
            _configurationAsset.Animator = TheUnityObject.InstanceFromAsset(_configurationAsset.Animator);
            _shootingComponent = new SkelmagShootingData(_configurationAsset.Ser, _configurationAsset.Hands);
            SkelmagMovementData movementData = new(_configurationAsset.Ser, _configurationAsset.transform, TheUnityObject.InstanceFromAsset(_configurationAsset.Animator));
            _coreSystem = new SkelmagCore(movementData, _shootingComponent, modelAsset, _bulletPrefab);
            _configurationAsset.HealthContext.Set(this);
            _extendedHealthSystem = new ExtendedHealth(_configurationAsset.HealthComponent, _configurationAsset.Ser.extendedHealth);
            _configurationAsset.HealthComponent.Value = _configurationAsset.HealthComponent.Max;
            _collisionContextAsset = TheUnityObject.InstanceFromAsset(_collisionContextAsset); /*можно вывести в компонент*/
            _collisionContextAsset.List.Add(_configurationAsset.transform);
        }
        public void Start() {
            _coreSystem.Start();
            _extendedHealthSystem.Start();
        }
        public void Update() {
            _extendedHealthSystem.Update();
            _configurationAsset.Barrel.LookAt(_shootingComponent.Target);
            Vector3 targetPosition = _shootingComponent.Target.position;
            targetPosition.y = _configurationAsset.transform.position.y;
            _configurationAsset.transform.LookAt(targetPosition);
        }
        public void Deal(float value) {
            if (value > 0) {
                _extendedHealthSystem.DealExtendedDamage(value);
            } else if (value < 0) {
                _extendedHealthSystem.HealExtendedDamage(-value);
            }
        }
    }
}
