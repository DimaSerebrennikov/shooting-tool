// ToggleAutoAim.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Range enemy\ToggleAutoAim.csToggleAutoAim.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Button = UnityEngine.UI.Button;
namespace Serebrennikov {
    public class ToggleAutoAim : MonoBehaviour {
        [SerializeField] Button _button;
        [SerializeField] AutoAimConfiguration _configAsset;
        void Awake() {
            _configAsset = TheUnityObject.InstanceFromAsset(_configAsset);
        }
        void Start() {
            _button.onClick.AddListener(() => {
                _configAsset.Set_Persistent(!_configAsset.Value);
            });
        }
    }
}
