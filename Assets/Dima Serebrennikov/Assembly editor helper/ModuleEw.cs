using System;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
public class ModuleEw : EditorWindow {
    string _folderPath;
    string _folderName = "NewModule";
    string _savedPrefix = "DimaSerebrennikov";
    [CanBeNull] Action<string, string> _onCreatingFolder;
    public static void Open(string path, Action<string, string> onCreatingFolder) {
        var window = CreateInstance<ModuleEw>();
        window._onCreatingFolder += onCreatingFolder;
        window._folderPath = path;
        window.titleContent = new GUIContent("Create Module");
        Rect main = GetEditorMainWindowPos();
        Vector2 size = new Vector2(300, 120);
        window.position = new Rect(main.x + (main.width - size.x) * 0.5f, main.y + (main.height - size.y) * 0.5f, size.x, size.y);
        window.minSize = size;
        window.maxSize = size;
        window.ShowUtility();
    }
    void CreateGUI() {
        var root = rootVisualElement;
        root.style.paddingLeft = 8;
        root.style.paddingRight = 8;
        root.style.paddingTop = 8;
        root.style.paddingBottom = 8;
        var header = new Label("Module Name");
        header.style.unityFontStyleAndWeight = FontStyle.Bold;
        header.style.marginBottom = 4;
        root.Add(header);
        var nameField = new TextField("Name:") {
            value = _folderName
        };
        nameField.RegisterValueChangedCallback(evt => _folderName = evt.newValue);
        root.Add(nameField);
        var prefixField = new TextField("Saved prefix:") {
            value = _savedPrefix
        };
        prefixField.RegisterValueChangedCallback(evt => _savedPrefix = evt.newValue);
        root.Add(prefixField);
        var spacer = new VisualElement();
        spacer.style.height = 8;
        root.Add(spacer);
        var buttonsRow = new VisualElement();
        buttonsRow.style.flexDirection = FlexDirection.Row;
        buttonsRow.style.justifyContent = Justify.FlexEnd;
        var createBtn = new Button(OnCreate) {
            text = "Create"
        };
        buttonsRow.Add(createBtn);
        root.Add(buttonsRow);
    }
    void OnCreate() {
        if (string.IsNullOrWhiteSpace(_folderName)) {
            EditorUtility.DisplayDialog("Error", "Name cannot be empty.", "OK");
            return;
        }
        string assemblyName = TheString.ToPascalCase(_folderName);
        TheAssembly.CreateFolderWithAssembly(_folderPath, _folderName, $"{_savedPrefix}.{assemblyName}", out string createdFolderPath);
        _onCreatingFolder?.Invoke(createdFolderPath, _folderName);
        Close();
    }
    public static class TheString {
        public static string ToPascalCase(string input) {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++) {
                string word = words[i];
                if (word.Length > 0) words[i] = char.ToUpperInvariant(word[0]) + word[1..];
            }
            return string.Join(string.Empty, words);
        }
    }

    static Rect GetEditorMainWindowPos() {
        var containerWinType = typeof(Editor).Assembly.GetType("UnityEditor.ContainerWindow");
        if (containerWinType == null) throw new MissingMemberException("Can't find internal type UnityEditor.ContainerWindow");
        var showModeField = containerWinType.GetField("m_ShowMode", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var positionProperty = containerWinType.GetProperty("position", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        var windows = Resources.FindObjectsOfTypeAll(containerWinType);
        foreach (var win in windows) {
            int showmode = (int)showModeField.GetValue(win);
            if (showmode == 4) // main window
                return (Rect)positionProperty.GetValue(win, null);
        }
        return new Rect(100, 100, 800, 600);
    }
}
