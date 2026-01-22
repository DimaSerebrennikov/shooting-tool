// BoxOpening.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxOpening.csBoxOpening.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public class BoxOpeningHud {
        BoxRenamingContainerHud _renamingContainerHud;
        Action<string> onDelete;
        Button delete;
        public BoxOpeningHud(BoxRenamingContainerHud renamingContainerHud, BoxElementHud elementHud, Action<string> onDelete) {
            _renamingContainerHud = renamingContainerHud;
            this.elementHud = elementHud;
            this.onDelete = onDelete;
            openedView = new VisualElement();
            textField = new TextField();
            delete = new Button();
        }
        public VisualElement openedView { get; }
        public VisualElement view => elementHud.visual;
        public TextField textField { get; }
        public BoxElementHud elementHud { get; }
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
            void OnDeleteOnclicked() {
                onDelete(elementHud.filePath);
            }
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
