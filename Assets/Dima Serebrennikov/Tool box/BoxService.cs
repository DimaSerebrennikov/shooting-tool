// BoxModule.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxModule.csBoxModule.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    /// It is shortcut
    public interface IFilePath {
        string filePath { get; set; }
    }
    /// It contains VisualElement
    public interface IVisual {
        VisualElement visual { get; set; }
    }
    /// It is object which has no parent, it is never inside other Folder
    public interface IFolderCore : IFilePath {
        List<ISystemEntry> children { get; set; }
    }
    /// It is either folder or file, the most abstract type inside ToolBase
    public interface ISystemEntry : IFilePath {
        IFolderCore parent { get; set; }
    }
    /// Is is visualization of the IFolder
    public interface IHudParent : IVisual {
        List<VisualElement> childrenViews { get; set; }
    }
    /// It is visualizaed root folder
    public interface IFolderHudCore : IFolderCore, IHudParent {}
    /// It is new folder concept
    public interface IFolder : IFolderCore, ISystemEntry {}
    /// It is visualized folder
    public interface IFolderHud : IFolder, IHudParent {}
    /// It is SystemEntry with full visualization
    public interface IEntryHud : ISystemEntry, IVisual {}
    public class BoxService {
        Action<IFolderCore> onUpdate;
        string _folderPath;
        VisualElement rootVisual;
        public BoxService(Action<IFolderCore> onUpdate, string folderPath, VisualElement rootVisual) {
            this.onUpdate = onUpdate;
            _folderPath = folderPath;
            this.rootVisual = rootVisual;
        }
        public void Update() {
            FolderCoreHud updatedFolderRoot = new(_folderPath, rootVisual);
            onUpdate(updatedFolderRoot);
        }
        public void AddFile_AsVm(ISystemEntry a) {
            if (a is IFolderHud asFolderHud) DrawFolder(asFolderHud);
        }
        public void RemoveFile(ISystemEntry a) {
            if (a is IFolderHud yes) EraseFolder(yes);
        }
        void EraseFolder(IFolderHud data) {
            if (data.parent is IHudParent yes) {
                BoxHud.RemoveFile(data.filePath, data.childrenViews, yes.visual);
            }
        }
        void DrawFolder(IFolderHud data) {
            if (data.parent is not IVisual parentHud) return;
            VisualElement parentVisual = parentHud.visual;
            string labelText = Path.GetFileName(data.filePath);
            BoxRenamingContainerHud renamingContainerHud = new();
            BoxElementHud boxElement = new(labelText, data.filePath, data.visual);
            BoxOpeningHud opening = new(renamingContainerHud, boxElement, TheBox.Delete);
            BoxRenamingHud renamingHud = new(opening, TheFile.RenameDirectory, renamingContainerHud);
            parentVisual.Add(data.visual);
            data.childrenViews.Add(boxElement.visual);
            BoxHud.AddFile(boxElement, opening, renamingHud, renamingContainerHud);
        }
    }
}
