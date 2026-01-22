// BoxModuel.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxModuel.csBoxModuel.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov.Tb {
    /// It is Vms facade
    public class BoxModule {
        BoxFolderVersionControlVm versionControl;
        BoxVm vm;
        public BoxModule(BoxFolderVersionControlVm versionControl, BoxVm vm) {
            this.versionControl = versionControl;
            this.vm = vm;
        }
        /// It adds a callback that waits for folder updates
        public IDisposable Add_Wait(Action<ISystemEntry> a) {
            return versionControl.Add_Wait(a);
        }
        /// It removes a previously added wait callback
        public IDisposable Remove_Wait(Action<ISystemEntry> a) {
            return versionControl.Remove_Wait(a);
        }
        /// It updates the view model with a folder and its nested structure
        public void UpdateWithNestedFolders(IFolderCore updatedData) {
            vm.UpdateWithNestedFolders(updatedData);
        }
    }
}
