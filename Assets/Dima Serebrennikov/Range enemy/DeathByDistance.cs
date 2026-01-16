// DeathByDistance.csC:\Feeble snow\Assets\Serebrennikov\Range enemy\DeathByDistance.csDeathByDistance.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class DeathByDistance : MonoBehaviour {
        [SerializeField] float _maxY;
        void FixedUpdate() {
            if (transform.position.y < _maxY) {
                Destroy(gameObject);
            }
        }
    }
}
