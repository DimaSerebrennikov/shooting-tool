using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class AutoAimConfiguration : MonoBehaviour {}
    public class RangeEnemy : MonoBehaviour {
        [SerializeField] LimitedValueContext _health;
        [SerializeField] EnemyBulletSystemContext _bulletSystemAsset;
        [SerializeField] Transform _barrel;
        [SerializeField] RangeEnemyConfiguration _attackSpeedAsset;
        PeriodicShaking _periodicShaking;
        [SerializeField] ShakingConfiguration _configuration;
        [SerializeField] SpreadConfiguration _spreadConfigurationAsset;
        [SerializeField] bool _autoAim;
        [SerializeField] Transform _barrelAiming;
        [SerializeField] Transform _target;
        Vector3 _startTargetPosition;
        const float _targetTime = 1f;
        float _attackTimer;
        void Awake() {
            _attackSpeedAsset = TheUnityObject.InstanceFromAsset(_attackSpeedAsset);
            _startTargetPosition = _configuration.ObjectToManipulate.localPosition;
            _bulletSystemAsset = TheUnityObject.InstanceFromAsset(_bulletSystemAsset);
            _spreadConfigurationAsset = TheUnityObject.InstanceFromAsset(_spreadConfigurationAsset);
            ShakingContext context = new(_configuration);
            _periodicShaking = new PeriodicShaking(context, context);
        }
        void Start() {
            _health.Value = _health.Max;
            _health.OnBottom += () => {
                Destroy(gameObject);
            };
            _periodicShaking.Start();
        }
        void Update() {
            _attackTimer -= _attackSpeedAsset.AttackSpeed * Time.deltaTime;
            Shoot();
        }
        void FixedUpdate() {
            if (_spreadConfigurationAsset.Value) {
                _periodicShaking.Update(Time.fixedDeltaTime);
            } else {
                _configuration.ObjectToManipulate.localPosition = _startTargetPosition;
            }
            if (_autoAim) {
                _barrelAiming.LookAt(_target);
            } else {
                _barrelAiming.rotation = default;
            }
        }
        void Shoot() {
            if (Time.timeScale <= 0f) return;
            if (_attackTimer <= 0f) {
                _attackTimer = _targetTime;
                _bulletSystemAsset.Add(_barrel.position, _barrel.rotation);
            }
        }
    }
}
