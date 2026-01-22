// YAxisLookAt.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\Cmd\Input\YAxisLookAt.csYAxisLookAt.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    /// Крутит игровой объект к цели только ось
    public class YAxisLookAt : MonoBehaviour {
        public Transform target;
        void Start() {
            target = TheUnityObject.InstanceFromAsset(target);
        }
        void Update() {
            if (!target) return;
            Vector3 direction = target.position - transform.position;
            direction.y = 0f;
            if (direction.sqrMagnitude > 0.001f) {
                Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = lookRotation;
            }
        }
    }
}
