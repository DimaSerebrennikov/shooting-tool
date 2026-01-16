using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
namespace Serebrennikov {
    public class SoaTestMb : MonoBehaviour {
        [SerializeField] GameObject _enemy;
        [SerializeField] GameObject _player;
        [SerializeField] float _speed;
        [SerializeField] int _count = 10;
        List<GameObject> _enemyList = new(); /*The whole point is to keep this particular object as simple as possible, down to the number, but since this is an engine, the game object should be here in any case*/
        List<Vector3> _positionList = new();
        void Start() {
            for (int i = 0; i < _count; i++) {
                NewEntity();
            }
        }
        void FixedUpdate() {
            for (int i = 0; i < _enemyList.Count; i++) {
                ProcessEntity(i);
            }
        }
        void ProcessEntity(int i) {
            Vector3 direction = _player.transform.position - _positionList[i];
            _positionList[i] += direction.normalized * (_speed * Time.fixedDeltaTime);
            _enemyList[i].transform.position = _positionList[i];
        }
        void NewEntity() {
            Vector3 randomVector = new Vector3(UnityEngine.Random.value * 10f, UnityEngine.Random.value* 10f, UnityEngine.Random.value* 10f);
            var n = Instantiate(_enemy, randomVector, Quaternion.identity);
            _enemyList.Add(n);
            _positionList.Add(n.transform.position);
        }
    }
}
