// RangeEnemyConfigurationInspector.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Range enemy\RangeEnemyConfigurationInspector.csRangeEnemyConfigurationInspector.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
namespace Serebrennikov {
    [CustomEditor(typeof(RangeEnemyConfiguration))]
    public class RangeEnemyConfigurationInspector : Editor {
        float _attackSpeed;
        void OnEnable() {
            _attackSpeed = ((RangeEnemyConfiguration)target).AttackSpeed;
        }
        public override void OnInspectorGUI() {
            DrawDefaultInspector();
            EditorGUILayout.BeginHorizontal();
            _attackSpeed = EditorGUILayout.FloatField(_attackSpeed);
            if (GUILayout.Button("Save", GUILayout.Width(48f))) {
                Apply();
            }
            EditorGUILayout.EndHorizontal();
        }
        void Apply() {
            RangeEnemyConfiguration config = (RangeEnemyConfiguration)target;
            Undo.RecordObject(config, "Set Attack Speed");
            config.SetAttackSpeedPersistent(_attackSpeed);
            EditorUtility.SetDirty(config);
        }
    }
}
