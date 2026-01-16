using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    interface IModulerListViewClient {
        List<string> assemblyList { get; }
        ListView assemblyListView { get; }
        Subject<int> onClick { get; }
    }
    class ModulerListViewClient_Assembly : IModulerListViewClient {
        public List<string> assemblyList => TheModuler.Service.Get<SelectionComponentContext>().projectAssemblyList;
        public ListView assemblyListView => TheModuler.Service.Get<SelectionComponentContext>().listView;
        public Subject<int> onClick => TheModuler.Service.Get<SelectionComponentContext>().listViewClicked;
        public void Start() {
            ModulerListView n = new(this);
            n.Start();
        }
    }
    class ModulerListViewClient_Filtered : IModulerListViewClient {
        public List<string> assemblyList => TheModuler.Service.Get<ModulerContext>().filteredList;
        public ListView assemblyListView => TheModuler.Service.Get<ModulerContext>().filteredView;
        public Subject<int> onClick => TheModuler.Service.Get<ModulerContext>().filteredViewClicked;
        public void Start() {
            ModulerListView n = new(this);
            n.Start();
        }
    }
    class ModulerListView {
        readonly IModulerListViewClient _a;
        public ModulerListView(IModulerListViewClient a) {
            _a = a;
        }
        List<string> _assemblyList => _a.assemblyList;
        ListView _assemblyListView => _a.assemblyListView;
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
