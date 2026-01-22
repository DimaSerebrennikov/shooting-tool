// FeebleSnowManager.csC:\Feeble snow\Assets\Serebrennikov\Feeble snow manager\FeebleSnowManager.csFeebleSnowManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class FeebleSnow : MonoBehaviour {
        [SerializeField] FeebleSnowConfigurationAsset _config;
        [SerializeField] RectTransform _validMouseArea;
        CamRotating _camRotating;
        CamWheelMoving _wheelMoving;
        CamSwiperAsNoRaycast _mapSwiper;
        void Awake() {
            _config = TheUnityObject.InstanceFromAsset(_config);
            Transform cameraPt = _config.cameraObject.transform;
            _mapSwiper = new CamSwiperAsNoRaycast(_config.cameraObject, cameraPt, _config);
            _camRotating = new CamRotating(_config.cameraObject, _config);
            _wheelMoving = new CamWheelMoving(_config.cameraObject, _config);
            GameObject cameraParent = new();
        }
        public void Update() {
            _camRotating.Update();
            if (ValidateZoom()) {
                _wheelMoving.Update();
            }
            _mapSwiper.Update();
        }
        bool ValidateZoom() {
            if (_validMouseArea == null) {
                return true;
            }
            return IsMouseInsideRectTransform(_validMouseArea);
        }
        bool IsMouseInsideRectTransform(RectTransform rect) {
            Vector2 mousePos = Input.mousePosition;
            return RectTransformUtility.RectangleContainsScreenPoint(rect, mousePos, null);
        }
    }
}
