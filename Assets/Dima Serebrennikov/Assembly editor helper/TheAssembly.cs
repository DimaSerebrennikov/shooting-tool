using UnityEditor;
using UnityEngine;
using System.IO;
public static class TheAssembly {
    internal static void CreateFolderWithAssembly(string parentPath, string folderName, string assemblyName, out string folderPath) {
        if (TheAssembly.CreateFolder(parentPath, folderName, out folderPath)) return;
        string asmdefPath = Path.Combine(folderPath, assemblyName + ".asmdef");
        if (!File.Exists(asmdefPath)) {
            string asmdefContent = $"{{\n  \"name\": \"{assemblyName}\"\n}}";
            File.WriteAllText(asmdefPath, asmdefContent);
            AssetDatabase.ImportAsset(asmdefPath);
        } else EditorUtility.DisplayDialog("Warning", $"{assemblyName}.asmdef already exists.", "OK");
        AssetDatabase.Refresh();
    }
    internal static bool CreateFolder(string parentPath, string folderName, out string folderPath) {
        folderPath = Path.Combine(parentPath, folderName);
        if (!AssetDatabase.IsValidFolder(folderPath)) AssetDatabase.CreateFolder(parentPath, folderName);
        else {
            EditorUtility.DisplayDialog("Warning", $"Folder '{folderName}' already exists.", "OK");
            return true;
        }
        return false;
    }
}
