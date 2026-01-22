// FolderCoreHud.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\FolderCoreHud.csFolderCoreHud.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public class FolderCoreHud : IFolderHudCore {
        public string filePath { get; set; }
        public VisualElement visual { get; set; }
        public List<ISystemEntry> children { get; set; }
        public List<VisualElement> childrenViews { get; set; }
        public FolderCoreHud(string filePath, VisualElement view) {
            this.filePath = filePath;
            visual = view;
            children = new List<ISystemEntry>();
            childrenViews = new List<VisualElement>();
        }
    }
}
