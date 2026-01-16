using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    class SetPositionForCamera : MonoBehaviour {
        [SerializeField] Camera _cameraAsset;
//        [SerializeField] Vector3 _startOffset;
//        [SerializeField] Quaternion _rotation;
        void Start() {
            _cameraAsset = TheUnityObject.InstanceFromAsset(_cameraAsset);
            _cameraAsset.transform.position = transform.position;
            _cameraAsset.transform.rotation = transform.rotation;
        }
//        void Shift() {
//            transform.Translate(_startOffset);
//            transform.rotation = _rotation;
//        }
    }
}
