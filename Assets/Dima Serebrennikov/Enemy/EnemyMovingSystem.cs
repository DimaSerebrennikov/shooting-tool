using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class EnemyMovingSystem {
        List<Vector3> _enemyPositionList;
        List<Vector3> _nextPositionList;
        Transform _target;
        float _speed;
        public void Update(float dt) {
            for (int i = 0; i < _enemyPositionList.Count; i++) {
                Vector3 direction = _target.position - _enemyPositionList[i];
                _enemyPositionList[i] += direction.normalized * _speed * dt;
            }
        }
    }
}