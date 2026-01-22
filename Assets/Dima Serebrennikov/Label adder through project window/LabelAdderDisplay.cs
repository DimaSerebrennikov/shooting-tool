// LabelAdderDisplay.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\LabelAdderDisplay.csLabelAdderDisplay.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
static class LabelAdderDisplay {
    static List<string> GetAllLabels() {
        string[] allGuids = AssetDatabase.FindAssets("", new[] {
            "Assets"
        }); // only in Assets/
        HashSet<string> labels = new();
        foreach (string guid in allGuids) {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Object obj = AssetDatabase.LoadMainAssetAtPath(path);
            if (obj == null) continue;
            foreach (string label in AssetDatabase.GetLabels(obj)) {
                if (!string.IsNullOrEmpty(label)) labels.Add(label);
            }
        }
        return new List<string>(labels);
    }
    public static void Populate(VisualElement root) {
        List<string> labels = GetAllLabels();
        ScrollView container = new();
        container.style.marginTop = 8;
        container.style.flexGrow = 1;
        if (labels.Count == 0) {
            container.Add(new Label("No labels found in project."));
        } else {
            foreach (string label in labels) {
                Button button = new(() => PingAssetsWithLabel(label)) {
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
    static void PingAssetsWithLabel(string label) {
        string[] guids = AssetDatabase.FindAssets("l:" + label, new[] {
            "Assets"
        }); // only Assets/
        List<Object> objs = new();
        foreach (string guid in guids) {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Object obj = AssetDatabase.LoadMainAssetAtPath(path);
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
