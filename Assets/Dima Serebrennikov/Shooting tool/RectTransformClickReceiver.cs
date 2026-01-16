// RectTransformClickReceiver.csC:\Feeble snow\Assets\Serebrennikov\Shooting tool\RectTransformClickReceiver.csRectTransformClickReceiver.cs
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
namespace Serebrennikov {
    class RectTransformClickReceiver : MonoBehaviour {
        [SerializeField] GameObject _parent;
        [SerializeField] GameObject _ctx;
        [SerializeField] Slider _slider;
        [SerializeField] TMP_InputField _min;
        [SerializeField] TMP_InputField _max;
        [SerializeField] MinMaxContext _minMaxContextAsset;
        RectTransform _rectTransform;
        MinMaxConfiguration _configuration;
        void Awake() {
            _rectTransform = (RectTransform)transform;
        }
        void Start() {
            _minMaxContextAsset = TheUnityObject.InstanceFromAsset(_minMaxContextAsset);
            for (int i = 0; i < _minMaxContextAsset.Value.Count; i++) {
                MinMaxData n = _minMaxContextAsset.Value[i];
                if (n.Parent == _parent) {
                    Configuration(n.Configuration);
                    break;
                }
            }
        }
        void Configuration(MinMaxConfiguration configuration) {
            _configuration = configuration;
            _slider.minValue = _configuration.Min;
            _slider.maxValue = _configuration.Max;
            _min.onValueChanged.AddListener(MinChanged);
            _max.onValueChanged.AddListener(MaxChanged);
        }
        void MinChanged(string text) {
            if (!Parse(text, out float value)) return;
            if (value > _slider.maxValue) {
                value = _slider.maxValue;
            }
            _slider.minValue = value;
            _configuration.Min = value;
        }
        void MaxChanged(string text) {
            if (!Parse(text, out float value)) return;
            if (value < _slider.minValue) {
                value = _slider.minValue;
            }
            _slider.maxValue = value;
            _configuration.Max = value;
        }
        bool Parse(string text, out float value) {
            return float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }
        void Update() {
            if (!Input.GetMouseButtonDown(0)) return;
            if (!IsMouseOver()) return;
            if (!IsCtrlPressed()) return;
            _ctx.SetActive(!_ctx.activeSelf);
        }
        bool IsMouseOver() {
            Vector2 mousePosition = Input.mousePosition;
            return RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, mousePosition);
        }
        bool IsCtrlPressed() {
            return Input.GetKey(KeyCode.LeftControl) ||
                Input.GetKey(KeyCode.RightControl);
        }
    }
}
