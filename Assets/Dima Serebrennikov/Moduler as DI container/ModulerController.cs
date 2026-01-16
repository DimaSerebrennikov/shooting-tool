using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
namespace Serebrennikov {
    class ModulerController {
        readonly List<string> _filtered;
        readonly ModulerLoading _loading;
        Subject<int> _filteredListViewClicked;
        ListView _filteredView;
        public ModulerController(
            [Inject(Id = "filteredList")] List<string> filtered,
            ModulerLoading loading,
            [Inject(Id = "filteredClicked")] Subject<int> click,
            [Inject(Id = "filteredView")] ListView filteredView
        ) {
            _filtered = filtered;
            _loading = loading;
            _filteredListViewClicked = click;
            _filteredView = filteredView;
        }
        void RemoveFromFilteredList(int i) {
            _filtered.RemoveAt(i);
            _loading.SaveFilteredAssemblies(_filtered);
        }
        public void Start() {
            _filteredListViewClicked.Subscribe(RemoveFromFilteredList);
            TheModuler.Bind_Rebuild(_filteredListViewClicked, _filteredView);
        }
    }
}
