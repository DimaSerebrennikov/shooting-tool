// ToggleCameraShaking.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Shooting tool\ToggleCameraShaking.csToggleCameraShaking.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
namespace Serebrennikov {
    class ToggleCameraShaking : MonoBehaviour {
        [SerializeField] Button _button;
        [SerializeField] bool isOn = true;
        [SerializeField] CameraController _cameraControllerAsset;
        void Awake() {
            _cameraControllerAsset = TheUnityObject.InstanceFromAsset(_cameraControllerAsset);
        }
        void Start() {
            _button.onClick.AddListener(() => {
                _cameraControllerAsset.IsSignaling = !_cameraControllerAsset.IsSignaling;
            });
        }
    }
}
