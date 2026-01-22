// TheLabelAdderAdding.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\TheLabelAdderAdding.csTheLabelAdderAdding.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
static class TheLabelAdderAdding {
    public static void AddLabelToSelection(string newLabel) {
        Object[] objs = Selection.objects;
        if (TheLabelAdder.CorrectLabel(newLabel)) return;
        if (TheLabelAdder.Selected(objs)) return;
        foreach (Object obj in objs) {
            Pass(obj, newLabel);
        }
        AssetDatabase.SaveAssets();
    }
    static void Pass(Object obj, string newLabel) {
        string path = AssetDatabase.GetAssetPath(obj);
        if (!string.IsNullOrEmpty(path)) {
            string[] labels = AssetDatabase.GetLabels(obj);
            ArrayUtility.Add(ref labels, newLabel);
            AssetDatabase.SetLabels(obj, labels);
        }
    }
}
