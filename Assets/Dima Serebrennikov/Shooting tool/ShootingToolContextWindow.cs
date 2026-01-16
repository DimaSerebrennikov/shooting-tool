// ShootingToolContextWindow.csC:\Feeble snow\Assets\Serebrennikov\Shooting tool\ShootingToolContextWindow.csShootingToolContextWindow.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    class ShootingToolContextWindow : MonoBehaviour {
        [SerializeField] GameObject _uiElement;
        void Update() {
            if (!IsCtrlAPressed()) return;
            _uiElement.SetActive(!_uiElement.activeSelf);
        }
        bool IsCtrlAPressed() {
            return IsCtrlHeld() && Input.GetKeyDown(KeyCode.A);
        }

        bool IsCtrlHeld() {
            return Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        }
    }
}
