using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class EnemyHealthSliderViewAddon : MonoBehaviour {
        [SerializeField] MeshRenderer _sliderViewPrefab;
        [SerializeField] LimitedValueContext _limitedValueContext;
        [SerializeField] Vector3 _offset;
        MeshRenderer _sliderView;
        static readonly int FillAmountID = Shader.PropertyToID("_FillAmount");
        void Awake() {
            _sliderView = Instantiate(_sliderViewPrefab);
            TheUnity.Link(_sliderView.transform, transform, _offset);
        }
        void OnEnable() {
            _limitedValueContext.OnChange += UpdateFill;
            UpdateFill();
        }
        void OnDisable() {
            _limitedValueContext.OnChange -= UpdateFill;
        }
        void OnDestroy() {
            Destroy(_sliderView);
        }
        void UpdateFill() {
            float t = (_limitedValueContext.Value - _limitedValueContext.Min) / (_limitedValueContext.Max - _limitedValueContext.Min);
            t = Mathf.Clamp01(t);
            _sliderView.material.SetFloat(FillAmountID, t);
        }
    }
}
