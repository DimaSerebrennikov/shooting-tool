// CameraSpot.csC:\Feeble snow\Assets\Serebrennikov\Feeble snow components\CameraSpot.csCameraSpot.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class CameraSpot : MonoBehaviour {
        [SerializeField] Camera _cameraAsset;
        void Awake() {
            _cameraAsset = TheUnityObject.InstanceFromAsset(_cameraAsset);
        }
        void Start() {
            _cameraAsset.transform.position = transform.position;
        }
    }
}
