// BoxRenamingContainer.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxRenamingContainer.csBoxRenamingContainer.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public class BoxRenamingContainerHud {
        Enterable _isRename;
        Button _renameButton;
        public BoxRenamingContainerHud() {
            _isRename = new();
            _renameButton = new();
        }
        public Enterable isRename => _isRename;
        public Button renameButton => _renameButton;
    }
}
