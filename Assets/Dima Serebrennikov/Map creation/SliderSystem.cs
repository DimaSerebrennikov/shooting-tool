using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class SliderSystem : MonoBehaviour {
        [SerializeField] MapContext _mapContextAsset;
        [SerializeField] MeshRenderer _sliderPrefab;
        [SerializeField] EnemyHealthContext _enemyHealthContext;
        static readonly int FillAmountID = Shader.PropertyToID("_FillAmount");
        void Awake() {
            _mapContextAsset = TheUnityObject.InstanceFromAsset(_mapContextAsset);
            _enemyHealthContext = TheUnityObject.InstanceFromAsset(_enemyHealthContext);
        }
        void Start() {
            _mapContextAsset.Created += component => {
                if (_enemyHealthContext.EnemyHealth.TryGetValue(component.gameObject, out IHealth result)) {
                    MeshRenderer newSliderRender = Instantiate(_sliderPrefab, component.gameObject.transform);
                    LimitedValueContext health = component.GetComponentInChildren<LimitedValueContext>();
                    health.OnChange += UpdateFill;
                    void UpdateFill() {
                        float t = (health.Value - health.Min) / (health.Max - health.Min);
                        t = Mathf.Clamp01(t);
                        newSliderRender.material.SetFloat(FillAmountID, t);
                    }
                }
            };
        }
    }
}
