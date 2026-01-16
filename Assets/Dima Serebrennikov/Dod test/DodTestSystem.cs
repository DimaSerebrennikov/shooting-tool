// DodTestSystem.csC:\Feeble snow\Assets\Serebrennikov\Dod test\DodTestSystem.csDodTestSystem.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    [Serializable]
    public class DodTestSystem {
        [SerializeField] float _speed;
        [SerializeField] Vector3 _target;
        public List<Vector3> PositionList { get; } = new();
        public void Process(int i) {
            Vector3 direction = _target - PositionList[i];
            PositionList[i] += direction.normalized * (_speed * Time.fixedDeltaTime);
        }
        public void SetTarget(Vector3 value) {
            _target = value;
        }
    }
}
