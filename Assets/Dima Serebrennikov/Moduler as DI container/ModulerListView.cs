using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
namespace Serebrennikov {
    abstract class ModulerListViewClient {
        public List<string> list { get; set; }
        public ListView listView { get; set; }
        public Subject<int> onClick { get; set; }
    }
    class ModulerListViewClient_Assembly : ModulerListViewClient {
        public ModulerListViewClient_Assembly(
            [Inject(Id = "assemblyList")] List<string> list,
            [Inject(Id = "assemblyView")] ListView listView,
            [Inject(Id = "assemblyClicked")] Subject<int> onClick) {
            this.list = list;
            this.listView = listView;
            this.onClick = onClick;
        }
        public void Start() {
            ModulerListView n = new(this);
            n.Start();
        }
    }
    class ModulerListViewClient_Filtered : ModulerListViewClient {
        public ModulerListViewClient_Filtered(
            [Inject(Id = "filteredList")] List<string> list,
            [Inject(Id = "filteredView")] ListView listView,
            [Inject(Id = "filteredClicked")] Subject<int> onClick) {
            this.list = list;
            this.listView = listView;
            this.onClick = onClick;
        }
        public void Start() {
            ModulerListView n = new(this);
            n.Start();
        }
    }
    class ModulerListView {
        readonly ModulerListViewClient _a;
        public ModulerListView(ModulerListViewClient a) {
            _a = a;
        }
        List<string> _assemblyList => _a.list;
        ListView _assemblyListView => _a.listView;
        Subject<int> _onClick => _a.onClick;
        public void Start() {
            _assemblyListView.itemsSource = _assemblyList;
            _assemblyListView.selectionType = SelectionType.Single;
            _assemblyListView.style.flexGrow = 1;
            _assemblyListView.style.marginTop = 6;
            _assemblyListView.makeItem = MakeItem;
            _assemblyListView.bindItem = BindItem;
            _assemblyListView.selectionType = SelectionType.None;
            _assemblyListView.Rebuild();
        }
        void BindItem(VisualElement element, int index) {
            Label label = element.Q<Label>();
            label.text = _assemblyList[index];
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
