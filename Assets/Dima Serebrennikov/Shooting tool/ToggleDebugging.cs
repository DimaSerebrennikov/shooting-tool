// ToggleDebugging.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Shooting tool\ToggleDebugging.csToggleDebugging.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
namespace Serebrennikov {
    class ToggleDebugging : MonoBehaviour {
        [SerializeField] Button _button;
        [SerializeField] GameObject[] _list;
        void Awake() {
            _button.onClick.AddListener(() => {
                for (int i = 0; i < _list.Length; i++) {
                    _list[i].SetActive(!_list[i].activeSelf);
                }
            });
        }
    }
}
