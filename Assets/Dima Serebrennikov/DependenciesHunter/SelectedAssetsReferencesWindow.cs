using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;
namespace DependenciesHunter {
    /// <summary>
    ///     Lists all references of the selected assets.
    /// </summary>
    public class SelectedAssetsReferencesWindow : EditorWindow {
        static SelectedAssetsAnalysisUtilities _service;
        static bool _cachedLaunchRequested;
        static bool _searchForAssetReferences;

        Dictionary<Object, List<string>> _lastResults;

        Object[] _selectedObjects;

        bool[] _selectedObjectsFoldouts;

        float _workTime;

        Vector2 _scrollPos = Vector2.zero;
        Vector2[] _foldoutsScrolls;

        [MenuItem("Assets/[DH] Find References In Project", false, 20)]
        public static void FindReferences() {
            SelectedAssetsReferencesWindow window = GetWindow<SelectedAssetsReferencesWindow>("Selected Assets");
            _cachedLaunchRequested = false;
            _searchForAssetReferences = false;
            window.Start();
        }

        [MenuItem("Assets/[DH] Find References In Project (Previous Cache)", false, 20)]
        public static void FindReferencesCached() {
            SelectedAssetsReferencesWindow window = GetWindow<SelectedAssetsReferencesWindow>("Selected Assets");
            _cachedLaunchRequested = true;
            _searchForAssetReferences = false;
            window.Start();
        }

#if HUNT_ADDRESSABLES
        [MenuItem("Assets/[DH] Find References In Project (incl Asset References)", false, 20)]
        public static void FindReferencesInclAssetReferences() {
            var window = GetWindow<SelectedAssetsReferencesWindow>("Selected Assets");
            _cachedLaunchRequested = false;
            _searchForAssetReferences = true;
            window.Start();
        }

        [MenuItem("Assets/[DH] Find References In Project (incl Asset References)(Previous Cache)", false, 20)]
        public static void FindReferencesCachedInclAssetReferences() {
            var window = GetWindow<SelectedAssetsReferencesWindow>("Selected Assets");
            _cachedLaunchRequested = true;
            _searchForAssetReferences = true;
            window.Start();
        }
#endif

        void Start() {
            if (!_cachedLaunchRequested || _service == null) {
                _service = new SelectedAssetsAnalysisUtilities();
            }
            Show();
            float startTime = Time.realtimeSinceStartup;
            _selectedObjects = Selection.objects;
            Stopwatch stopWatch = new();
            stopWatch.Start();
            _lastResults = _service.GetReferences(_selectedObjects,
                _searchForAssetReferences,
                EditorSettings.serializationMode != SerializationMode.ForceText);
            EditorUtility.DisplayProgressBar("DependenciesHunter", "Preparing Assets", 1f);
            EditorUtility.UnloadUnusedAssetsImmediate();
            EditorUtility.ClearProgressBar();
            _workTime = Time.realtimeSinceStartup - startTime;
            _selectedObjectsFoldouts = new bool[_selectedObjects.Length];
            if (_selectedObjectsFoldouts.Length >= 7) {
                _selectedObjectsFoldouts[0] = true;
            } else {
                for (int i = 0; i < _selectedObjectsFoldouts.Length; i++) {
                    _selectedObjectsFoldouts[i] = true;
                }
            }
            _foldoutsScrolls = new Vector2[_selectedObjectsFoldouts.Length];
            stopWatch.Stop();
            Debug.Log($"Scanning took: {stopWatch.Elapsed.TotalSeconds} sec");
        }

        void Clear() {
            _selectedObjects = null;
            _service = null;
            EditorUtility.UnloadUnusedAssetsImmediate();
        }

        void OnGUI() {
            if (_lastResults == null) {
                return;
            }
            if (_selectedObjects == null || _selectedObjects.Any(selectedObject => selectedObject == null)) {
                Clear();
                return;
            }
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUIUtilities.DrawColoredLabel($"Analysis done in: {_workTime:0.00} s", Color.gray);
            bool hasCollapsed = _selectedObjectsFoldouts.Any(x => !x);
            bool hasExpanded = _selectedObjectsFoldouts.Any(x => x);
            Color prevColor = GUI.color;
            GUI.color = hasCollapsed ? Color.white : Color.gray;
            if (GUILayout.Button("Expand All")) {
                for (int i = 0; i < _selectedObjectsFoldouts.Length; i++) {
                    _selectedObjectsFoldouts[i] = true;
                }
            }
            GUI.color = hasExpanded ? Color.white : Color.gray;
            if (GUILayout.Button("Collapse All")) {
                for (int i = 0; i < _selectedObjectsFoldouts.Length; i++) {
                    _selectedObjectsFoldouts[i] = false;
                }
            }
            GUI.color = prevColor;
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            Dictionary<Object, List<string>> results = _lastResults;
            _scrollPos = GUILayout.BeginScrollView(_scrollPos);
            for (int i = 0; i < _selectedObjectsFoldouts.Length; i++) {
                GUIUtilities.HorizontalLine();
                List<string> dependencies = results[_selectedObjects[i]];
                if (dependencies.Count > 0) {
                    GUILayout.BeginHorizontal();
                    _selectedObjectsFoldouts[i] = GUIUtilities.DrawColoredFoldout(_selectedObjectsFoldouts[i], " >>> ", Color.white);
                    string selectedObjectPath = AssetDatabase.GetAssetPath(_selectedObjects[i]);
                    GUIUtilities.DrawAssetButton(selectedObjectPath, 300f, 18f);
                    GUIUtilities.DrawColoredLabel($" has [{dependencies.Count}] " + (dependencies.Count == 1 ? "dependency" : "dependencies"), Color.white);
                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                    if (_selectedObjectsFoldouts[i]) {
                        const float itemHeight = 18f;
                        _foldoutsScrolls[i] = GUILayout.BeginScrollView(_foldoutsScrolls[i],
                            GUILayout.MinHeight(dependencies.Count * (itemHeight + 2f) + 10f));
                        GUILayout.Space(10f);
                        foreach (string resultPath in dependencies) {
                            EditorGUILayout.BeginHorizontal();
                            GUILayout.Space(15f);
                            GUIUtilities.DrawAssetButton(resultPath, 300f, itemHeight);
                            GUILayout.FlexibleSpace();
                            EditorGUILayout.EndHorizontal();
                        }
                        GUILayout.EndScrollView();
                    }
                } else {
                    GUILayout.BeginHorizontal();
                    GUILayout.Space(55f);
                    string selectedObjectPath = AssetDatabase.GetAssetPath(_selectedObjects[i]);
                    GUIUtilities.DrawAssetButton(selectedObjectPath, 300f, 18f);
                    GUIUtilities.DrawColoredLabel("has [0] dependencies", Color.yellow);
                    GUILayout.FlexibleSpace();
                    EditorGUILayout.EndHorizontal();
                    bool isAddressable = CommonUtilities.IsAssetAddressable(selectedObjectPath);
                    if (isAddressable) {
                        GUIUtilities.DrawColoredLabel("*please notice that this asset is an addressable and can be accessed via AssetReference or code", Color.yellow);
                    }
                    bool isInResources = selectedObjectPath.Contains("/Resources/") ||
                        selectedObjectPath.Contains("\\Resources\\");
                    if (isInResources) {
                        GUIUtilities.DrawColoredLabel("*please notice that this asset is in Resources and can be accessed via code", Color.yellow);
                    }
                }
            }
            GUILayout.EndScrollView();
            GUILayout.EndVertical();
        }

        void OnProjectChange() {
            Clear();
        }

        void OnDestroy() {
            Clear();
        }
    }
}