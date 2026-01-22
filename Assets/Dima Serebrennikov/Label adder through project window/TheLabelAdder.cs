// TheLabelAdder.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\TheLabelAdder.csTheLabelAdder.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
static class TheLabelAdder {
    public static bool Selected(Object[] objs) {
        if (objs == null || objs.Length == 0) {
            EditorUtility.DisplayDialog("Error", "No objects selected in Project window.", "OK");
            return true;
        }
        return false;
    }
    public static bool CorrectLabel(string newLabel) {
        if (string.IsNullOrEmpty(newLabel)) {
            EditorUtility.DisplayDialog("Error", "Please enter a label.", "OK");
            return true;
        }
        return false;
    }
}
