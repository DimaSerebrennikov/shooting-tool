using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal class ModulerListView {
        List<string> _list;
        ListView _listView;
        Subject<int> _onClick;
        public ModulerListView(List<string> list, ListView listView, Subject<int> onClick) {
            _list = list;
            _listView = listView;
            _onClick = onClick;
        }
        public void Start() {
            _listView.itemsSource = _list;
            _listView.selectionType = SelectionType.Single;
            _listView.style.flexGrow = 1;
            _listView.style.marginTop = 6;
            _listView.makeItem = MakeItem;
            _listView.bindItem = BindItem;
            _listView.selectionType = SelectionType.None;
            _listView.Rebuild();
        }
        void BindItem(VisualElement element, int index) {
            Label label = element.Q<Label>();
            label.text = _list[index];
            element.userData = index;
            element.UnregisterCallback<PointerDownEvent>(OnItemPointerDown);
            element.RegisterCallback<PointerDownEvent>(OnItemPointerDown);
        }
        void OnItemPointerDown(PointerDownEvent evt) {
            VisualElement element = (VisualElement)evt.currentTarget;
            int index = (int)element.userData;
            _onClick.OnNext(index);
        }
        VisualElement MakeItem() {
            Label label = new();
            label.style.unityFontStyleAndWeight = FontStyle.Normal;
            label.style.paddingLeft = 4;
            label.style.paddingTop = 4;
            label.style.paddingBottom = 4;
            label.style.unityTextAlign = TextAnchor.MiddleLeft;
            return label;
        }
    }
}
