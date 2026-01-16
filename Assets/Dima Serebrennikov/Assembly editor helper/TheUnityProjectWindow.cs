// TheUnityProjectWindow.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\TheUnityProjectWindow.csTheUnityProjectWindow.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
internal static class TheUnityProjectWindow {
    internal static string GetSelectedFolderPath() {
        Type projectWindowUtil = typeof(ProjectWindowUtil);
        MethodInfo method = projectWindowUtil.GetMethod("GetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);
        return method != null ? (string)method.Invoke(null, null) : "Assets";
    }
}
