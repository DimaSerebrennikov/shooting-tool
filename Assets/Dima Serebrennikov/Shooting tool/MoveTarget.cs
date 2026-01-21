// MoveTarget.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Shooting tool\MoveTarget.csMoveTarget.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    class MoveTarget : MonoBehaviour {
        [SerializeField] Transform _target;
        [SerializeField] float _speed = 5f;
        void Update() {
            Vector3 direction = Vector3.zero;
            if (Input.GetKey(KeyCode.W)) {
                direction += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S)) {
                direction += Vector3.back;
            }
            if (Input.GetKey(KeyCode.A)) {
                direction += Vector3.left;
            }
            if (Input.GetKey(KeyCode.D)) {
                direction += Vector3.right;
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                direction += Vector3.up;
            }
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) {
                direction += Vector3.down;
            }
            if (direction.sqrMagnitude > 0f) {
                _target.position += direction.normalized * (_speed * Time.deltaTime);
            }
        }
    }
}
