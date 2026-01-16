// ModularSelectionView.csC:\Feeble snow\Assets\Serebrennikov\Module manager\ModularSelectionView.csModularSelectionView.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
namespace Serebrennikov {
    class ModulerSelectionView {
        VisualElement _splitContainer => TheModuler.Service.Get<ModulerContext>().splitContainer;
        ListView _listView => TheModuler.Service.Get<SelectionComponentContext>().listView;
        VisualElement _component;
        public void Start() {
            _component = CreateRoot();
            VisualElement header = CreateHeader();
            Label titleLabel = CreateTitle();
            ObjectField selectionField = CreateSelectionField();
            Button removeButton = CreateRemoveButton();
            header.Add(titleLabel);
            header.Add(selectionField);
            header.Add(removeButton);
            _component.Add(header);
            _component.Add(_listView);
            _listView.style.flexGrow = 1;
            _listView.style.flexBasis = 0;
            _splitContainer.Add(_component);
        }
        VisualElement CreateRoot() {
            VisualElement root = new();
            root.style.flexDirection = FlexDirection.Column;
            root.style.flexGrow = 1;
            return root;
        }
        VisualElement CreateHeader() {
            VisualElement header = new();
            header.style.flexDirection = FlexDirection.Row;
            header.style.alignItems = Align.Center;
            header.style.marginBottom = 4;
            return header;
        }
        Label CreateTitle() {
            Label label = new("Module");
            label.style.unityFontStyleAndWeight = FontStyle.Bold;
            label.style.marginRight = 6;
            return label;
        }
        ObjectField CreateSelectionField() {
            ObjectField field = new();
            field.objectType = typeof(Object);
            field.style.flexGrow = 1;
            field.style.marginRight = 6;
            return field;
        }
        Button CreateRemoveButton() {
            Button button = new(OnRemoveClicked);
            button.text = "✖";
            button.style.width = 24;
            button.style.height = 20;
            return button;
        }
        void OnRemoveClicked() {
            _component?.RemoveFromHierarchy();
        }
    }
}
