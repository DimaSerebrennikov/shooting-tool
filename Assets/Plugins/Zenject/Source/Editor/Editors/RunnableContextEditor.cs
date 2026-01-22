using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
#if !ODIN_INSPECTOR
using UnityEditor;

namespace Zenject {
    [NoReflectionBaking]
    public class RunnableContextEditor : ContextEditor {
        SerializedProperty _autoRun;

        public override void OnEnable() {
            base.OnEnable();
            _autoRun = serializedObject.FindProperty("_autoRun");
        }

        protected override void OnGui() {
            base.OnGui();
            EditorGUILayout.PropertyField(_autoRun);
        }
    }
}


#endif
