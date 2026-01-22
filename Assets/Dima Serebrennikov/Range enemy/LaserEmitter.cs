// LaserEmitter.csC:\Feeble snow\Assets\Serebrennikov\Range enemy\LaserEmitter.csLaserEmitter.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    [ExecuteAlways]
    public class LaserEmitter : MonoBehaviour {
        [Header("Laser Settings")]
        [SerializeField] float _maxDistance = 25f;
        [SerializeField] float _startWidth = 0.05f;
        [SerializeField] float _endWidth = 0.05f;
        [SerializeField] LineRenderer _lineRenderer;
        void Start() {
            _Start();
        }
        void OnValidate() {
            _Start();
        }
        void Update() {
            Vector3 originPosition = transform.position;
            Vector3 targetPosition = originPosition + transform.forward * _maxDistance;
            _lineRenderer.SetPosition(0, originPosition);
            _lineRenderer.SetPosition(1, targetPosition);
        }
        void _Start() {
            _lineRenderer.positionCount = 2;
            _lineRenderer.useWorldSpace = true;
            _lineRenderer.startWidth = _startWidth;
            _lineRenderer.endWidth = _endWidth;
        }
    }
}
