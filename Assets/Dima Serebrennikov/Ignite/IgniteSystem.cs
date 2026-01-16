// IgniteManager.csC:\Feeble snow\Assets\Serebrennikov\Ignite\IgniteManager.csIgniteManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class IgniteSystem : MonoBehaviour {
        [SerializeField] BulletContext _bulletContextAsset;
        [SerializeField] Transform _playerTransformAssset;
        [SerializeField] EnemyHealthContext _enemyHpCtxAsset; /*Enemy health context*/
        [SerializeField] PlayerHealthContext _playerHpCtxAsset;
        [SerializeField] Component _igniteVisualConfig; /*Ignite visual configuration*/
        [SerializeField] float _distanceToHeal = 1f;
        [SerializeField] float _healScale = 10f;
        [SerializeField] float _damageScale = 0.1f;
        [SerializeField] MeshRenderer _debugSpherePrefab;
        MeshRenderer _debugSphere;
        List<Ignite> _activeIgnites = new(); /*List of active ignites*/
        void Awake() {
            _bulletContextAsset = TheUnityObject.InstanceFromAsset(_bulletContextAsset);
            _playerTransformAssset = TheUnityObject.InstanceFromAsset(_playerTransformAssset);
            _enemyHpCtxAsset = TheUnityObject.InstanceFromAsset(_enemyHpCtxAsset);
            _playerHpCtxAsset = TheUnityObject.InstanceFromAsset(_playerHpCtxAsset);
            _debugSphere = Instantiate(_debugSpherePrefab);
        }
        void Start() {
            _bulletContextAsset.OnTrigger += OnTrigger;
        }
        void UpdateDebugHealArea() {
            _debugSphere.transform.localScale = Vector3.one * (_distanceToHeal * 2f);
            _debugSphere.transform.position = _playerTransformAssset.position;
        }
        void OnTrigger(GameObject a) {
            _enemyHpCtxAsset.EnemyHealth.TryGetValue(a, out var health);
            if (health == null) return;
            Component n = Instantiate(_igniteVisualConfig);
            Ignite item = new(a, n.gameObject, health);
            _activeIgnites.Add(item);
        }
        void Update() {
            for (int i = _activeIgnites.Count - 1; i >= 0; i--) {
                Ignite n = _activeIgnites[i];
                if (n.Enemy != null) {
                    n.View.transform.position = n.Enemy.transform.position;
                    n.EnemyHealth.Deal(Time.deltaTime * _damageScale);
                } else {
                    Destroy(n.View);
                    _activeIgnites.RemoveAt(i);
                }
            }
            Heal();
            UpdateDebugHealArea();
        }
        void Heal() {
            for (int i = 0; i < _activeIgnites.Count; i++) {
                if (Vector3.Distance(_activeIgnites[i].View.transform.position, _playerTransformAssset.position) < _distanceToHeal) {
                    _playerHpCtxAsset.Deal(-Time.deltaTime * _healScale);
                }
            }
        }
        class Ignite {
            public Ignite(GameObject enemy, GameObject view, IHealth enemyHealth) {
                Enemy = enemy;
                View = view;
                EnemyHealth = enemyHealth;
            }
            public GameObject Enemy;
            public GameObject View;
            public IHealth EnemyHealth;
        }
    }
}
