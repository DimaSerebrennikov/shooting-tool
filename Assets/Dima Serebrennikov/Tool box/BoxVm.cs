// BoxVm_1.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxVm_1.csBoxVm_1.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    /// It sets folder and file logic together
    public class BoxVm {
        BoxFolderVm _folderVm;
        BoxFolderVersionControlVm _version;
        IFolderCore actualData;
        string filePath;
        public BoxVm(BoxFolderVm folderVm, BoxFolderVersionControlVm version, string filePath, IFolderCore actualData) {
            _folderVm = folderVm;
            _version = version;
            this.filePath = filePath;
            this.actualData = actualData;
        }
        /// It gets data from OS folder to update actual data
        public void UpdateWithNestedFolders(IFolderCore updatedData) {
            TakeOsData(filePath, updatedData);
            _version.UpdateFileTree(actualData, updatedData);
        }
        /// It gets new data each frame
        public void TakeOsData(string aFilePath, IFolderCore parent) {
            _folderVm.PassOsFolder(aFilePath, OnPass);
            return;
            void OnPass(string path) {
                _folderVm.HandleFolder(path, parent);
            }
        }
    }
}
