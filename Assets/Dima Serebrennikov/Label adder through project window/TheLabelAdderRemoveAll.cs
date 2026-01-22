// TheLabelAdderRemoveAll.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\TheLabelAdderRemoveAll.csTheLabelAdderRemoveAll.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
static class TheLabelAdderRemoveAll {
    public static void RemoveAllLabelsFromSelection() {
        Object[] objs = Selection.objects;
        if (TheLabelAdder.Selected(objs)) return;
        foreach (Object obj in objs) {
            string path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path)) {
                AssetDatabase.SetLabels(obj, Array.Empty<string>()); // clear all labels
            }
        }
        AssetDatabase.SaveAssets();
    }
}
