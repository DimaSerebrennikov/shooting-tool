// BoxEditor.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxEditor.csBoxEditor.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
namespace Serebrennikov.Tb {
    public class BoxEw : EditorWindow {
        BoxService _service;
        [MenuItem("Serebrennikov/Box")]
        public static void ShowWindow() {
            BoxEw window = GetWindow<BoxEw>();
            window.titleContent = new GUIContent("Box");
        }
        void CreateGUI() {
            _service = TheBox.GetBoxService(rootVisualElement);
        }
        void Update() {
            _service.Update();
        }
    }
}
