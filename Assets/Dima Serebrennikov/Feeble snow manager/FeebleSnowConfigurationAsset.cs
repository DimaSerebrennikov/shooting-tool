// FeebleSnow.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\FeebleSnow.csFeebleSnow.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class FeebleSnowConfigurationAsset : MonoBehaviour, ICamSense, ICameraWheelData {
        [SerializeField] Camera _cameraPacked;
        [SerializeField] float _x;
        [SerializeField] float _y;
        [SerializeField] float _smoothTime;
        [SerializeField] float _maxHeight;
        [SerializeField] float _minHeight;
        [SerializeField] float _scrollSensitivity;
        [SerializeField] bool _invert;
        [SerializeField] float _rotatingSpeed;
        public float x => _x;
        public float y => _y;
        public float smoothTime { get => _smoothTime; set => _smoothTime = value; }
        public float maxHeight { get => _maxHeight; set => _maxHeight = value; }
        public float minHeight { get => _minHeight; set => _minHeight = value; }
        public float scrollSensitivity { get => _scrollSensitivity; set => _scrollSensitivity = value; }
        public bool invert { get => _invert; set => _invert = value; }
        public float rotatingSpeed { get => _rotatingSpeed; set => _rotatingSpeed = value; }
        public Camera cameraObject { get; set; }
        void Awake() {
            cameraObject = TheUnityObject.InstanceFromAsset(_cameraPacked);
        }
    }
}
