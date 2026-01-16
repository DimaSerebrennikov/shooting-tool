using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
public static class BlankPrefabCreator {
    [MenuItem("Assets/Create/Serebrennikov/Prefab", false, -1000)]
    [MenuItem("Assets/Serebrennikov/Prefab", false, 1)]
    public static void CreateBlankPrefab() {
        string targetFolder = GetSelectedFolderPath();
        string prefabPath = AssetDatabase.GenerateUniqueAssetPath(targetFolder + "/Blank Prefab.prefab");
        GameObject temporaryObject = new GameObject("Blank Prefab");
        PrefabUtility.SaveAsPrefabAsset(temporaryObject, prefabPath);
        Object.DestroyImmediate(temporaryObject);
        AssetDatabase.Refresh();
        Selection.activeObject = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
    }
    internal static string GetSelectedFolderPath() {
        Type projectWindowUtil = typeof(ProjectWindowUtil);
        MethodInfo method = projectWindowUtil.GetMethod("GetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);
        return method != null ? (string)method.Invoke(null, null) : "Assets";
    }
}
