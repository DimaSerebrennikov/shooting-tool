// FolderExtendedData.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\FolderExtendedData.csFolderExtendedData.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public class FolderHud : IFolderHud {
        public string filePath { get; set; }
        public VisualElement visual { get; set; }
        public List<ISystemEntry> children { get; set; }
        public List<VisualElement> childrenViews { get; set; }
        public IFolderCore parent { get; set; }
        public FolderHud(string filePath, VisualElement view, IFolderCore parent) {
            this.filePath = filePath;
            this.visual = view;
            this.parent = parent;
            children = new();
            childrenViews = new();
        }
    }
}
