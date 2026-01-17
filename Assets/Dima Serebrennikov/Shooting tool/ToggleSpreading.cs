// ToggleSpreading.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Shooting tool\ToggleSpreading.csToggleSpreading.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
namespace Serebrennikov {
    class ToggleSpreading : MonoBehaviour {
        [SerializeField] SpreadConfiguration _configurationAsset;
        [SerializeField] Button _button;
        bool _state;
        void Awake() {
            _configurationAsset = TheUnityObject.InstanceFromAsset(_configurationAsset);
            _button.onClick.AddListener(() => {
                _state = !_state;
                _configurationAsset.Set_Persistent(_state);
            });
        }
    }
}
