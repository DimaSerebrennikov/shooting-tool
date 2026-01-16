// DodTestMb.csC:\Feeble snow\Assets\Serebrennikov\Dod test\DodTestMb.csDodTestMb.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class DodTestMb : MonoBehaviour {
        [SerializeField] int _count = 10;
        [SerializeField] DodTestSystem _system;
        [SerializeField] GameObject _enemy;
        [SerializeField] GameObject _player;
        List<GameObject> _enemyList = new(); /*The whole point is to keep this particular object as simple as possible, down to the number, but since this is an engine, the game object should be here in any case*/
        void Start() {
            for (int i = 0; i < _count; i++) {
                NewEntity();
            }
        }
        void FixedUpdate() {
            _system.SetTarget(_player.transform.position);
            for (int i = 0; i < _enemyList.Count; i++) {
                _system.Process(i);
                _enemyList[i].transform.position = _system.PositionList[i];
            }
        }
        void NewEntity() {
            Vector3 randomVector = new Vector3(UnityEngine.Random.value * 10f, UnityEngine.Random.value * 10f, UnityEngine.Random.value * 10f);
            var n = Instantiate(_enemy, randomVector, Quaternion.identity);
            _enemyList.Add(n);
            _system.PositionList.Add(n.transform.position);
        }
    }
}
