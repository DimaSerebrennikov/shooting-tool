// Toggle3dModel.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Shooting tool\Toggle3dModel.csToggle3dModel.cs
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
namespace Serebrennikov {
    class Toggle3dModel : MonoBehaviour {
        [SerializeField] Transform _target;
        [SerializeField] ModelAndSize[] _prefabs;
        [SerializeField] Slider _slider;
        [SerializeField] Transform _currentModel;
        [SerializeField] TextMeshProUGUI _valueText;
        void Awake() {
            _slider.minValue = 0;
            _slider.maxValue = _prefabs.Length - 1;
            _slider.onValueChanged.AddListener(OnSliderChanged);
            ShowModel(0);
        }
        void OnSliderChanged(float value) {
            ShowModel((int)value);
            _valueText.text = value.ToString();
        }
        void ShowModel(int prefabIndex) {
            if (_currentModel != null) {
                Destroy(_currentModel.gameObject);
            }
            Transform prefab = _prefabs[prefabIndex].Prefab;
            _currentModel = Instantiate(prefab, _target, false);
            _currentModel.localScale = Vector3.one * _prefabs[prefabIndex].Size;
        }
    }
}
