using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
namespace DependenciesHunter {
    public static class DependenciesMapUtilities {
        public static void FillReverseDependenciesMap(bool scanAssetReferences, bool binarySerialization, out Dictionary<string, List<string>> reverseDependencies) {
            List<string> assetPaths = AssetDatabase.GetAllAssetPaths().ToList();
            reverseDependencies = assetPaths.ToDictionary(assetPath => assetPath, _ => new List<string>());
            Debug.Log($"Total Assets Count: {assetPaths.Count}");
            for (int i = 0; i < assetPaths.Count; i++) {
                EditorUtility.DisplayProgressBar("Dependencies Hunter", "Creating a map of dependencies",
                    (float)i / assetPaths.Count);
                string[] assetDependencies =
                    scanAssetReferences
                        ? GetAllDependencies(assetPaths[i], binarySerialization, false)
                        : AssetDatabase.GetDependencies(assetPaths[i], false);
                foreach (string assetDependency in assetDependencies) {
                    if (reverseDependencies.ContainsKey(assetDependency) && assetDependency != assetPaths[i]) {
                        reverseDependencies[assetDependency].Add(assetPaths[i]);
                    }
                }
            }
        }

        static readonly Regex GuidRegex = new(@"m_AssetGUID:\s*([0-9a-fA-F]{32})",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);

        static string[] GetAllDependencies(string assetPath, bool binarySerialization, bool recursive = true) {
            string[] regularDependencies = AssetDatabase.GetDependencies(assetPath, recursive);
            if (!CanContainAssetReferencesByExtension(assetPath)) {
                return regularDependencies;
            }
            if (binarySerialization) {
                Object obj = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
                if (obj == null) {
                    return regularDependencies;
                }
                HashSet<string> result = null;
                SerializedObject serializedObj = new(obj);
                SerializedProperty iterator = serializedObj.GetIterator();
                while (iterator.NextVisible(true)) {
                    if (iterator.propertyType != SerializedPropertyType.Generic ||
                        !iterator.type.Contains("AssetReference")) {
                        continue;
                    }
                    SerializedProperty guidProp = iterator.FindPropertyRelative("m_AssetGUID");
                    if (guidProp == null || string.IsNullOrEmpty(guidProp.stringValue)) {
                        continue;
                    }
                    string refPath = AssetDatabase.GUIDToAssetPath(guidProp.stringValue);
                    if (!string.IsNullOrEmpty(refPath)) {
                        result ??= regularDependencies.ToHashSet();
                        result.Add(refPath);
                    }
                }
                return result != null ? result.ToArray() : regularDependencies;
            } else {
                if (!File.Exists(assetPath)) {
                    return regularDependencies;
                }
                string content = File.ReadAllText(assetPath);
                if (!content.Contains("m_AssetGUID")) {
                    return regularDependencies;
                }
                HashSet<string> result = null;
                foreach (Match match in GuidRegex.Matches(content)) {
                    if (match == null || match.Groups.Count <= 1) {
                        continue;
                    }
                    string guid = match.Groups[1].Value;
                    if (string.IsNullOrEmpty(guid)) {
                        continue;
                    }
                    string refPath = AssetDatabase.GUIDToAssetPath(guid);
                    if (!string.IsNullOrEmpty(refPath)) {
                        result ??= regularDependencies.ToHashSet();
                        result.Add(refPath);
                    }
                }
                return result != null ? result.ToArray() : regularDependencies;
            }
        }

        static bool CanContainAssetReferencesByExtension(string assetPath) {
            string extension = Path.GetExtension(assetPath).ToLowerInvariant();
            switch (extension) {
                case ".asset":
                case ".prefab":
                case ".unity":
                    return true;
                default:
                    return false;
            }
        }
    }
}