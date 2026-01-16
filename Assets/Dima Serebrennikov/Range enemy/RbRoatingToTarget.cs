// RbRoatingToTarget.csC:\Feeble snow\Assets\Serebrennikov\Range enemy\RbRoatingToTarget.csRbRoatingToTarget.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class RbRoatingToTarget : MonoBehaviour {
        [SerializeField] Rigidbody _rb;
        [SerializeField] Transform _target;
        [SerializeField] float _rotationSpeed;
        void FixedUpdate() {
            Vector3 directionToTarget = _target.position - _rb.position;
            if (directionToTarget.sqrMagnitude < 0.0001f) {
                return;
            }
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
            Quaternion newRotation = Quaternion.RotateTowards(
                _rb.rotation,
                targetRotation,
                _rotationSpeed * Time.fixedDeltaTime
                );
            _rb.MoveRotation(newRotation);
        }
        public float RotationSpeed {
            get => _rotationSpeed;
            set => _rotationSpeed = value;
        }
    }
}
