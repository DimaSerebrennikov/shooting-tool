// DampingConfiguration.csC:\Feeble snow\Assets\Serebrennikov\Shooting tool\DampingConfiguration.csDampingConfiguration.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;
namespace Serebrennikov {
    class DampingConfiguration : MonoBehaviour {
        [SerializeField] ShootingElementCreator _creator;
        [SerializeField] List<FloatConfiguration> _configuration;
        [SerializeField] List<MinMaxConfiguration> _minMaxConfiguration;
        [SerializeField] MinMaxContext _minMaxContextAsset;
        void Awake() {
            _minMaxContextAsset = TheUnityObject.InstanceFromAsset(_minMaxContextAsset);
            for (int i = 0; i < _configuration.Count; i++) {
                int index = i;
                ShootingToolElement n = _creator.Add();
                MinMaxData minMaxData = new(_minMaxConfiguration[i], n.gameObject);
                _minMaxContextAsset.Value.Add(minMaxData);
                n.Tmp.text = Math.Round(_configuration[index].Value, 2).ToString();
                n.Name.text = _minMaxConfiguration[index].name; /*пока через это, поскольку там имена лучше*/
                SetValueIgnoringTheClamp(n.Slider, _configuration[index].Value);
                n.Slider.onValueChanged.AddListener(a => {
                    _configuration[index].Value = a;
                    n.Tmp.text = Math.Round(_configuration[index].Value, 2).ToString();
                });
            }
        }
        void SetValueIgnoringTheClamp(Slider slider, float value) {
            if (value < slider.minValue) {
                slider.minValue = value;
            } else if (value > slider.maxValue) {
                slider.maxValue = value;
            }
            slider.value = value;
        }
    }
}
