// ToggleDebugging.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Shooting tool\ToggleDebugging.csToggleDebugging.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Button = UnityEngine.UI.Button;
namespace Serebrennikov {
    class ToggleDebugging : MonoBehaviour {
        [SerializeField] Button _button;
        [SerializeField] GameObject[] _list;
        [SerializeField] DebugConfiguration _configAsset;
        void Start() {
            Debug.Log("start toggle debugging");
            _configAsset = TheUnityObject.InstanceFromAsset(_configAsset);
            UpdateView();
            _button.onClick.AddListener(() => {
                _configAsset.Set_Persistent(!_configAsset.Value);
                UpdateView();
            });
            Debug.Log("finish toggle debugging");
        }
        void UpdateView() {
            for (int i = 0; i < _list.Length; i++) {
                _list[i].SetActive(_configAsset.Value);
            }
        }
    }
}
