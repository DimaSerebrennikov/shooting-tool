// BoxRenaming.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxRenaming.csBoxRenaming.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public class BoxRenamingHud {
        BoxRenamingContainerHud _containerHud;
        BoxOpeningHud opening;
        Button applyButton;
        Button cancelButton;
        Action<string, string> onApply;
        public BoxRenamingHud(BoxOpeningHud opening, Action<string, string> onApply, BoxRenamingContainerHud containerHud) {
            _containerHud = containerHud;
            this.opening = opening;
            applyButton = new();
            cancelButton = new();
            this.onApply = onApply;
        }
        public void ShowRenaming() {
            opening.openedView.Remove(_containerHud.renameButton);
            opening.view.Remove(opening.elementHud.label);
            opening.textField.value = opening.elementHud.labelText;
            applyButton.clicked += Apply;
            cancelButton.clicked += _containerHud.isRename.Quit;
            applyButton.text = "Apply";
            cancelButton.text = "Cancel";
            opening.view.Insert(0, opening.textField);
            opening.openedView.Add(applyButton);
            opening.openedView.Add(cancelButton);
            return;
            void Apply() => onApply(opening.elementHud.filePath, opening.textField.value);
        }
        public void Cancel() {
            opening.openedView.TryRemove(applyButton);
            opening.openedView.TryRemove(cancelButton);
            opening.view.TryRemove(opening.textField);
            opening.view.Insert(0, opening.elementHud.label);
            opening.openedView.Add(_containerHud.renameButton);
        }
    }
}
