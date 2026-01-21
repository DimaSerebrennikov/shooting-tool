// ShootingToolContextWindow.csC:\Feeble snow\Assets\Serebrennikov\Shooting tool\ShootingToolContextWindow.csShootingToolContextWindow.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    class ShootingToolContextWindow : MonoBehaviour {
        [SerializeField] GameObject _uiElement;
        void Update() {
            if (!IsCtrlAPressed()) return;
            _uiElement.SetActive(!_uiElement.activeSelf);
        }
        bool IsCtrlAPressed() {
            return Input.GetKeyDown(KeyCode.C);
        }
    }
}
