// BoxRenamingContainer.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxRenamingContainer.csBoxRenamingContainer.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public class BoxRenamingContainerHud {
        public BoxRenamingContainerHud() {
            isRename = new Enterable();
            renameButton = new Button();
        }
        public Enterable isRename { get; }
        public Button renameButton { get; }
    }
}
