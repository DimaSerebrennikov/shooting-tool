using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal class BulletData : IMovePosition, ITimerResult {
        Transform _transform;
        public float Speed { get; set; }
        public BulletData(Transform transform, float speed) {
            _transform = transform;
            Speed = speed;
        }
        public Vector3 Direction { get; set; }
        public Vector3 Position { get => _transform.position; set => _transform.position = value; }
        public Vector3 Forward { get => _transform.forward; set => _transform.forward = value; }
        public bool TimeIsOut { get; set; }
    }
}
