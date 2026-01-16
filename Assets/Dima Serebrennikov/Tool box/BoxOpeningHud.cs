// BoxOpening.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxOpening.csBoxOpening.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public class BoxOpeningHud {
        BoxRenamingContainerHud _renamingContainerHud;
        BoxElementHud _elementHud;
        Action<string> onDelete;
        VisualElement _openedView;
        TextField _textField;
        Button delete;
        public BoxOpeningHud(BoxRenamingContainerHud renamingContainerHud, BoxElementHud elementHud, Action<string> onDelete) {
            this._renamingContainerHud = renamingContainerHud;
            _elementHud = elementHud;
            this.onDelete = onDelete;
            _openedView = new();
            _textField = new();
            delete = new();
        }
        public VisualElement openedView => _openedView;
        public VisualElement view => _elementHud.visual;
        public TextField textField => _textField;
        public BoxElementHud elementHud => _elementHud;
        public void OnOpenClick(PointerUpEvent evt) {
            SetOpenViewStyle(openedView);
            view.Insert(1, openedView);
            openedView.Add(delete);
            openedView.Add(_renamingContainerHud.renameButton);
        }
        public void SetOpenViewStyle(VisualElement a) {
            a.style.flexDirection = FlexDirection.Row;
            a.style.flexWrap = Wrap.Wrap;
            a.style.flexShrink = 0f;
            a.style.alignSelf = Align.Center;
        }
        public void SetOpenContext() {
            Get_Button("Delete", delete);
            Get_Button("Rename", _renamingContainerHud.renameButton);
            delete.clicked += OnDeleteOnclicked;
            _renamingContainerHud.renameButton.clicked += _renamingContainerHud.isRename.Enter;
            return;
            void OnDeleteOnclicked() => onDelete(elementHud.filePath);
        }
        public void Get_Button(string name, Button button) {
            button.text = name;
            ContextualButtonView.SetStyle(button);
        }
        public void Close() {
            _renamingContainerHud.isRename.Quit();
            openedView.RemoveFromHierarchy();
            openedView.Clear();
        }
    }
}
