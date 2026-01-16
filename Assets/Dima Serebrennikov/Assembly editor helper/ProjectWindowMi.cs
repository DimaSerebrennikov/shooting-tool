// ProjectWindowDuplicator.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\ProjectWindowDuplicator.csProjectWindowDuplicator.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
static class ProjectWindowMi {
    [MenuItem("Serebrennikov/Project window completely")]
    static void Do() {
        var projectBrowserType = typeof(Editor).Assembly.GetType("UnityEditor.ProjectBrowser");
        EditorWindow window = ScriptableObject.CreateInstance(projectBrowserType) as EditorWindow;
        window.Show();
    }
}
