using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class EnemyBulletSystemCollision : MonoBehaviour {
        [SerializeField] List<Transform> _targets;
        [SerializeField] SplashSystemBehaviour _splashSystem;
        List<float> _bulletTimers = new(); /*entity = i*/
        List<EnemyBulletCollision> _views = new(); /*Single source of truth*/ /*entity is i*/
        void Update() {
            List<EnemyBulletCollision> onCollision = new();
            for (int k = 0; k < _targets.Count; k++) {
                Transform target = _targets[k];
                for (int i = 0; i < _views.Count; i++) {
                    for (int j = 0; j < _views[i].Collisions.Count; j++) {
                        Transform collision = _views[i].Collisions[j];
                        if (collision == target) {
                            Debug.Log(target.name);
                            Vector3 directionToTarget = _views[i].transform.position - collision.position;
                            _splashSystem.Create(_views[i].transform.position, directionToTarget, Color.blue);
                            onCollision.Add(_views[i]);
                            break;
                        }
                    }
                }
            }
            for (int i = onCollision.Count - 1; i >= 0; i--) {
                EnemyBulletCollision view = onCollision[i];
                int index = _views.IndexOf(view);
                if (index == -1) {
                    continue;
                }
                Destroy(view.gameObject);
                _views.RemoveAt(index);
                _bulletTimers.RemoveAt(index);
            }
            onCollision.Clear();
        }
    }
    public class EnemyBulletSystem : MonoBehaviour {
        [SerializeField] Transform _targetAsset;
        [SerializeField] EnemyBulletSystemContext _contextAsset;
        [SerializeField] EnemyBulletCollision _bulletPrefab;
        [SerializeField] float _bulletSpeed = 3f;
        [SerializeField] PlayerHealthContext _playerHealthContext;
        [SerializeField] SplashSystemBehaviour _splashSystem;
        [SerializeField] float _gravityRotationSpeed = 5f;
        [SerializeField] float _targetTimeToRemoveBullet = 2f;
        [SerializeField] List<Transform> _targets;
        List<EnemyBulletCollision> _views = new(); /*Single source of truth*/ /*entity is i*/
        List<float> _bulletTimers = new(); /*entity = i*/
        void Awake() {
            _targetAsset = TheUnityObject.InstanceFromAsset(_targetAsset);
            _contextAsset = TheUnityObject.InstanceFromAsset(_contextAsset);
            _playerHealthContext = TheUnityObject.InstanceFromAsset(_playerHealthContext);
            _splashSystem = TheUnityObject.InstanceFromAsset(_splashSystem);
        }
        void Update() {
            View();
            Move();
            Collide();
            Timer();
        }
        void View() {
            for (int i = 0; i < _contextAsset.AddedBullets.Count; i++) { /*visualize new bullets*/
                EnemyBullet n = _contextAsset.AddedBullets[i];
                EnemyBulletCollision view = Instantiate(_bulletPrefab, _contextAsset.AddedBullets[i].Position, _contextAsset.AddedBullets[i].Rotation);
                _views.Add(view); /*overflow, use "added/removed" pattern*/
                _bulletTimers.Add(0f);
            }
        }
        void Move() {
            _contextAsset.AddedBullets.Clear();
            for (int i = 0; i < _views.Count; i++) {
                EnemyBulletCollision view = _views[i];
                Transform bulletTransform = view.transform;
                bulletTransform.Rotate(_gravityRotationSpeed * Time.deltaTime, 0f, 0f, Space.Self);
                bulletTransform.position += bulletTransform.forward * (_bulletSpeed * Time.deltaTime);
            }
        }
        void Collide() {
            List<EnemyBulletCollision> onCollision = new();
            for (int k = 0; k < _targets.Count; k++) {
                Transform target = _targets[k];
                for (int i = 0; i < _views.Count; i++) {
                    for (int j = 0; j < _views[i].Collisions.Count; j++) {
                        Transform collision = _views[i].Collisions[j];
                        if (collision == target) {
                            Debug.Log(target.name);
                            Vector3 directionToTarget = _views[i].transform.position - collision.position;
                            _splashSystem.Create(_views[i].transform.position, directionToTarget, Color.blue);
                            onCollision.Add(_views[i]);
                            break;
                        }
                    }
                }
            }
            for (int i = onCollision.Count - 1; i >= 0; i--) {
                EnemyBulletCollision view = onCollision[i];
                int index = _views.IndexOf(view);
                if (index == -1) {
                    continue;
                }
                Destroy(view.gameObject);
                _views.RemoveAt(index);
                _bulletTimers.RemoveAt(index);
            }
            onCollision.Clear();
        }
        /*Проходит по всем коллизиям объекта и если цель равна указанной, то наносит урон.*/
        void HitPlayer() {
            List<EnemyBulletCollision> onCollision = new();
            for (int i = 0; i < _views.Count; i++) { /*check collisions*/
                for (int j = 0; j < _views[i].Collisions.Count; j++) {
                    Transform collision = _views[i].Collisions[j];
                    if (collision == _targetAsset) {
                        _playerHealthContext.Deal(1f);
                        Vector3 directionToTarget = _views[i].transform.position - collision.position;
                        _splashSystem.Create(_views[i].transform.position, directionToTarget, Color.blue);
                        onCollision.Add(_views[i]);
                        break;
                    }
                }
                _views[i].Collisions.Clear();
            }
            for (int i = onCollision.Count - 1; i >= 0; i--) {
                EnemyBulletCollision view = onCollision[i];
                int index = _views.IndexOf(view);
                if (index == -1) {
                    continue;
                }
                Destroy(view.gameObject);
                _views.RemoveAt(index);
                _bulletTimers.RemoveAt(index);
            }
            onCollision.Clear();
        }
        void Timer() {
            List<EnemyBulletCollision> removingByTime = new();
            for (int i = 0; i < _bulletTimers.Count; i++) {
                _bulletTimers[i] += Time.deltaTime;
                if (_bulletTimers[i] >= _targetTimeToRemoveBullet) {
                    removingByTime.Add(_views[i]);
                }
            }
            for (int i = removingByTime.Count - 1; i >= 0; i--) {
                EnemyBulletCollision view = removingByTime[i];
                int index = _views.IndexOf(view);
                if (index == -1) {
                    continue;
                }
                Destroy(view.gameObject);
                _views.RemoveAt(index);
                _bulletTimers.RemoveAt(index);
            }
        }
    }
}
