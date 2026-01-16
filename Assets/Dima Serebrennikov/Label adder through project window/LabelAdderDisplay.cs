// LabelAdderDisplay.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\LabelAdderDisplay.csLabelAdderDisplay.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
internal static class LabelAdderDisplay {
    static List<string> GetAllLabels() {
        var allGuids = AssetDatabase.FindAssets("", new[] {
            "Assets"
        }); // only in Assets/
        HashSet<string> labels = new HashSet<string>();
        foreach (var guid in allGuids) {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var obj = AssetDatabase.LoadMainAssetAtPath(path);
            if (obj == null) continue;
            foreach (var label in AssetDatabase.GetLabels(obj)) {
                if (!string.IsNullOrEmpty(label)) labels.Add(label);
            }
        }
        return new List<string>(labels);
    }
    public static void Populate(VisualElement root) {
        var labels = LabelAdderDisplay.GetAllLabels();
        var container = new ScrollView();
        container.style.marginTop = 8;
        container.style.flexGrow = 1;
        if (labels.Count == 0) {
            container.Add(new Label("No labels found in project."));
        } else {
            foreach (var label in labels) {
                var button = new Button(() => LabelAdderDisplay.PingAssetsWithLabel(label)) {
                    text = label
                };
                button.style.marginBottom = 4;
                container.Add(button);
            }
        }
        root.Add(new Label("Available Labels:") {
            style = {
                unityFontStyleAndWeight = FontStyle.Bold
            }
        });
        root.Add(container);
    }
    private static void PingAssetsWithLabel(string label) {
        var guids = AssetDatabase.FindAssets("l:" + label, new[] {
            "Assets"
        }); // only Assets/
        List<Object> objs = new List<Object>();
        foreach (var guid in guids) {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var obj = AssetDatabase.LoadMainAssetAtPath(path);
            if (obj != null) objs.Add(obj);
        }
        if (objs.Count > 0) {
            Selection.objects = objs.ToArray();
            EditorGUIUtility.PingObject(objs[0]);
        } else {
            EditorUtility.DisplayDialog("Not Found", $"No assets with label '{label}' found in Assets folder.", "OK");
        }
    }
}
