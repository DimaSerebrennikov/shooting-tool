using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace DependenciesHunter {
    public static class GUIUtilities {
        static void HorizontalLine(
            int marginTop,
            int marginBottom,
            int height,
            Color color
        ) {
            EditorGUILayout.BeginHorizontal();
            Rect rect = EditorGUILayout.GetControlRect(
                false,
                height,
                new GUIStyle {
                    margin = new RectOffset(0, 0, marginTop, marginBottom)
                }
                );
            EditorGUI.DrawRect(rect, color);
            EditorGUILayout.EndHorizontal();
        }

        public static void HorizontalLine(
            int marginTop = 5,
            int marginBottom = 5,
            int height = 2
        ) {
            HorizontalLine(marginTop, marginBottom, height, new Color(0.5f, 0.5f, 0.5f, 1));
        }

        public static bool DrawColoredFoldout(bool value, string text, Color color) {
            Color prevColor = GUI.color;
            GUI.color = color;
            bool result = EditorGUILayout.Foldout(value, text);
            GUI.color = prevColor;
            return result;
        }

        public static void DrawColoredLabel(string text, Color color) {
            Color prevColor = GUI.color;
            GUI.color = color;
            GUILayout.Label(text);
            GUI.color = prevColor;
        }

        public static void DrawAssetButton(string assetPath, float minWidth, float height) {
            Type selectedObjectType = AssetDatabase.GetMainAssetTypeAtPath(assetPath);
            GUIContent selectedObjectContent = EditorGUIUtility.ObjectContent(null, selectedObjectType);
            selectedObjectContent.text = Path.GetFileName(assetPath);
            TextAnchor alignment = GUI.skin.button.alignment;
            GUI.skin.button.alignment = TextAnchor.MiddleLeft;
            if (GUILayout.Button(selectedObjectContent, GUILayout.MinWidth(minWidth), GUILayout.Height(height))) {
                Selection.objects = new[] {
                    AssetDatabase.LoadMainAssetAtPath(assetPath)
                };
            }
            GUI.skin.button.alignment = alignment;
        }
    }
}