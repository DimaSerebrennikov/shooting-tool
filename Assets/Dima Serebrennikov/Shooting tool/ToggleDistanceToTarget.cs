// ToggleDistanceToTarget.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Shooting tool\ToggleDistanceToTarget.csToggleDistanceToTarget.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
namespace Serebrennikov {
    public class ToggleDistanceToTarget : MonoBehaviour {
        [SerializeField] Slider _slider;
        [SerializeField] Transform _target;
        [SerializeField] float _value;
        void Update() {
            _target.localPosition = new Vector3(_target.localPosition.x, _target.localPosition.y, _value);
        }
    }
}
