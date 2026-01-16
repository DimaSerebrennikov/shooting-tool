using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
namespace DependenciesHunter {
    public class SelectedAssetsAnalysisUtilities {
        Dictionary<string, List<string>> _cachedAssetsMap;

        public Dictionary<Object, List<string>> GetReferences(Object[] selectedObjects, bool scanAssetReferences, bool binarySerialization) {
            if (selectedObjects == null) {
                Debug.Log("No selected objects passed");
                return new Dictionary<Object, List<string>>();
            }
            if (_cachedAssetsMap == null) {
                DependenciesMapUtilities.FillReverseDependenciesMap(scanAssetReferences, binarySerialization, out _cachedAssetsMap);
            }
            EditorUtility.ClearProgressBar();
            GetDependencies(selectedObjects, _cachedAssetsMap, out Dictionary<Object, List<string>> result);
            return result;
        }

        static void GetDependencies(IEnumerable<Object> selectedObjects, IReadOnlyDictionary<string,
            List<string>> source, out Dictionary<Object, List<string>> results) {
            results = new Dictionary<Object, List<string>>();
            foreach (Object selectedObject in selectedObjects) {
                string selectedObjectPath = AssetDatabase.GetAssetPath(selectedObject);
                if (source.ContainsKey(selectedObjectPath)) {
                    results.Add(selectedObject, source[selectedObjectPath]);
                } else {
                    Debug.LogWarning("Dependencies Hunter doesn't contain the specified object in the assets map",
                        selectedObject);
                    results.Add(selectedObject, new List<string>());
                }
            }
        }
    }
}