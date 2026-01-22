// EnemyHealthSliderVisualizationManager.csC:\Feeble snow\Assets\Serebrennikov\Enemy\EnemyHealthSliderVisualizationManager.csEnemyHealthSliderVisualizationManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class EnemyHealthSliderView : MonoBehaviour {
        [SerializeField] MeshRenderer _sliderRenderer;
        [SerializeField] LimitedValueContext _limitedValueContext;
        static readonly int FillAmountID = Shader.PropertyToID("_FillAmount");
        void OnEnable() {
            _limitedValueContext.OnChange += UpdateFill;
            UpdateFill();
        }
        void OnDisable() {
            _limitedValueContext.OnChange -= UpdateFill;
        }
        void UpdateFill() {
            float t = (_limitedValueContext.Value - _limitedValueContext.Min) / (_limitedValueContext.Max - _limitedValueContext.Min);
            t = Mathf.Clamp01(t);
            _sliderRenderer.material.SetFloat(FillAmountID, t);
        }
    }
}
