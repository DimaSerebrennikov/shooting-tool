using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    class MoveToTarget {
        Transform _target;
        float _speed;
        Transform _source;
        public MoveToTarget(Transform target, float speed, Transform source) {
            _target = target;
            _speed = speed;
            _source = source;
        }
        public void Update(float dt) {
            Vector3 direction = _target.position - _source.position;
            _source.position += direction.normalized * (_speed * dt);
        }
    }
}
