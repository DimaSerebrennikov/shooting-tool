// BoxFolderVersionControl_1.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxFolderVersionControl_1.csBoxFolderVersionControl_1.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov.Tb {
    public class BoxFolderVersionControlVm {
        Action<ISystemEntry> add;
        Action<ISystemEntry> remove;
        public IDisposable Add_Wait(Action<ISystemEntry> a) {
            add += a;
            return new Disposer(OnDisposing);
            void OnDisposing() {
                add -= a;
            }
        }
        public IDisposable Remove_Wait(Action<ISystemEntry> a) {
            remove += a;
            return new Disposer(OnDisposing);
            void OnDisposing() {
                remove -= a;
            }
        }
        /// It reucsively updates each nested folder in "actualData"
        public void UpdateFileTree(IFolderCore actualData, IFolderCore updatedData) {
            Adding(actualData, updatedData);
            Removing(actualData, updatedData);
        }
        /// It tries to add new folder to "actualData" if it is in updated version
        void Adding(IFolderCore actual, IFolderCore updated) {
            for (int i = 0; i < updated.children.Count; i++) {
                ISystemEntry newChild = updated.children[i];
                int index = FindIndexByFilePath(actual.children, newChild.filePath);
                if (index == -1) {
                    TransferUpdatedDataToActualData(actual, newChild);
                } else {
                    UpdateFileTreeFolder(actual, i, newChild);
                }
            }
        }
        /// It invokes event that new folder is added
        void TransferUpdatedDataToActualData(IFolderCore actual, ISystemEntry newChild) {
            newChild.parent = actual;
            actual.children.Add(newChild);
            Pass(actual, newChild);
        }
        /// 
        public void Pass(IFolderCore parent, ISystemEntry newChild) {
            add(newChild);
            if (newChild is IFolderCore yes) {
                for (int j = 0; j < yes.children.Count; j++) {
                    Pass(yes, yes.children[j]);
                }
            }
        }
        /// It goes inside updatedFolder to see what there
        void UpdateFileTreeFolder(IFolderCore actual, int i, ISystemEntry newChild) {
            if (actual.children[i] is IFolderCore actualOne /**/
                && newChild is IFolderCore updatedOne) {
                UpdateFileTree(actualOne, updatedOne);
            }
        }
        /// It tries to remove folders from "actualData" that are not in updated version
        void Removing(IFolderCore actual, IFolderCore updated) {
            for (int i = actual.children.Count - 1; i >= 0; i--) {
                ISystemEntry existingChild = actual.children[i];
                if (FindIndexByFilePath(updated.children, existingChild.filePath) == -1) {
                    remove(actual.children[i]);
                    actual.children.RemoveAt(i);
                }
            }
        }
        /// It finds index of the object in parent list, if it did not find than "-1"
        int FindIndexByFilePath(IEnumerable<IFilePath> list, string filePath) {
            int index = 0;
            foreach (IFilePath n in list) {
                index++;
                if (n.filePath == filePath) return index;
            }
            return -1;
        }
    }
}
