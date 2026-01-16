using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class BulletHook : MonoBehaviour {
        Action<Transform> _onTriggerEnter = (_) => {};
        void OnTriggerEnter(Collider other) {
            _onTriggerEnter(other.transform);
        }
        public void SetRegistration(Action<Transform> registration) {
            _onTriggerEnter = registration;
        }
    }
}