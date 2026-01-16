// BoxAdding.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxAdding.csBoxAdding.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public class BoxHud {
        public static void AddFile(BoxElementHud elementHud, BoxOpeningHud openingHud, BoxRenamingHud renamingHud, BoxRenamingContainerHud renameContainerHud) {
            elementHud.isOpen.WaitEnter(openingHud.OnOpenClick);
            elementHud.isOpen.WaitQuit(openingHud.Close);
            renameContainerHud.isRename.WaitEnter(renamingHud.ShowRenaming);
            renameContainerHud.isRename.WaitQuit(renamingHud.Cancel);
            openingHud.SetOpenContext();
            elementHud.SetBoxElement();
        }
        public static void RemoveFile(string filePath, List<VisualElement> actualViews, VisualElement parent) {
            for (int i = 0; i < actualViews.Count; i++) {
                if (actualViews[i].name == filePath) {
                    parent.TryRemove(actualViews[i]);
                    actualViews.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
