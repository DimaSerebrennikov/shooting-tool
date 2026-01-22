// BoxFolderVm_1.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxFolderVm_1.csBoxFolderVm_1.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov.Tb {
    /// It handles only folder logic
    public class BoxFolderVm {
        Func<string, IFolderCore, IFolder> _getFolder;
        Action<string, IFolder> onPassChildren;
        public BoxFolderVm(Func<string, IFolderCore, IFolder> getFolder, Action<string, IFolder> onPassChildren) {
            _getFolder = getFolder;
            this.onPassChildren = onPassChildren;
        }
        /// It creates folder
        public void HandleFolder(string filePath, IFolderCore parent) {
            IFolder child = _getFolder(filePath, parent);
            onPassChildren(filePath, child);
            parent.children.Add(child);
        }
        /// It passes folder at given path and executes event
        public void PassOsFolder(string folderPath, Action<string> on) {
            string[] subfolders = Directory.GetDirectories(folderPath);
            for (int i = 0; i < subfolders.Length; i++) {
                on(subfolders[i]);
            }
        }
    }
}
