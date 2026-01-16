// BoxModuleExtension.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxModuleExtension.csBoxModuleExtension.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    /// It creates BoxModule and BoxService
    public static class TheBox {
        /// It createse box service
        public static BoxService GetBoxService(VisualElement rootVisual) {
            string folderPath = TheFile.AssureFolderAtPersistentPath("ToolBox");
            FolderCoreHud rootFolder = new(folderPath, rootVisual);
            BoxModule module = TheBox.GetBoxModule(folderPath, rootVisual, GetFolder);
            BoxService service = new(module.UpdateWithNestedFolders, folderPath, rootVisual);
            module.Add_Wait(service.AddFile_AsVm);
            module.Remove_Wait(service.RemoveFile);
            return service;
        }
        /// It is factory method
        public static BoxModule GetBoxModule(string filePath, VisualElement root, Func<string, IFolderCore, IFolder> getFolder) {
            Action<string, IFolder> stub = null;
            FolderCoreHud actualData = new(filePath, root);
            BoxFolderVersionControlVm versionControl = new();
            BoxFolderVm folder = new(getFolder, OnPassChildren);
            BoxVm vm = new(folder, versionControl, filePath, actualData);
            stub += vm.TakeOsData;
            return new(versionControl, vm);
            void OnPassChildren(string p, IFolder p1) => stub?.Invoke(p, p1);
        }
        /// It creates folder
        public static IFolder GetFolder(string filePath, IFolderCore parent) {
            VisualElement visualElement = new();
            visualElement.name = filePath;
            FolderHud data = new(filePath, visualElement, parent);
            return data;
        }
        /// It removes entire folder at the given path from file system
        public static void Delete(string filePath) {
            Directory.Delete(filePath, true);
        }
    }
}
