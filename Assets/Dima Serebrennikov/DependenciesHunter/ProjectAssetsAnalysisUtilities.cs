using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;
namespace DependenciesHunter {
    public class ProjectAssetsAnalysisUtilities {
        List<string> _iconPaths;

        public bool IsValidAssetType(string path, bool validForOutput) {
            Type type = AssetDatabase.GetMainAssetTypeAtPath(path);
            if (type == null) {
                if (validForOutput) {
                    Debug.LogWarning($"Invalid asset type found at {path}");
                }
                return false;
            }
            if (type == typeof(MonoScript) || type == typeof(DefaultAsset)) {
                return false;
            }
            if (type == typeof(SceneAsset)) {
                EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
                if (scenes.Any(scene => scene.path == path)) {
                    return false;
                }
            }
            return type != typeof(Texture2D) || !UsedAsProjectIcon(path);
        }

        public static bool IsValidForOutput(string path, List<string> ignoreInOutputPatterns) {
            return ignoreInOutputPatterns.All(pattern
                => string.IsNullOrEmpty(pattern) || !Regex.Match(path, pattern).Success);
        }

        bool UsedAsProjectIcon(string texturePath) {
            if (_iconPaths == null) {
                FindAllIcons();
            }
            return _iconPaths != null && _iconPaths.Contains(texturePath);
        }

        void FindAllIcons() {
            _iconPaths = new List<string>();
            List<Texture2D> icons = new();
            #if UNITY_2021_2_OR_NEWER
            foreach (FieldInfo buildTargetField in typeof(NamedBuildTarget).GetFields(BindingFlags.Public | BindingFlags.Static)) {
                if (buildTargetField.Name == "Unknown") {
                    continue;
                }
                if (buildTargetField.FieldType != typeof(NamedBuildTarget)) {
                    continue;
                }
                NamedBuildTarget buildTarget = (NamedBuildTarget)buildTargetField.GetValue(null);
                icons.AddRange(PlayerSettings.GetIcons(buildTarget, IconKind.Any));
            }
            #else
            foreach (var targetGroup in Enum.GetValues(typeof(BuildTargetGroup))) {
                icons.AddRange(PlayerSettings.GetIconsForTargetGroup((BuildTargetGroup)targetGroup));
            }
            #endif
            foreach (Texture2D icon in icons) {
                _iconPaths.Add(AssetDatabase.GetAssetPath(icon));
            }
        }
    }
}
