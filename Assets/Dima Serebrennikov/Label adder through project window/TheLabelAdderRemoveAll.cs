// TheLabelAdderRemoveAll.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\TheLabelAdderRemoveAll.csTheLabelAdderRemoveAll.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
internal static class TheLabelAdderRemoveAll {
    public static void RemoveAllLabelsFromSelection() {
        var objs = Selection.objects;
        if (TheLabelAdder.Selected(objs)) return;
        foreach (var obj in objs) {
            string path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path)) {
                AssetDatabase.SetLabels(obj, Array.Empty<string>()); // clear all labels
            }
        }
        AssetDatabase.SaveAssets();
    }
}
