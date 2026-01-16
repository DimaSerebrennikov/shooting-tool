using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    class SelectionComponentBinder {
        Subject<int> listViewClicked => TheModuler.Service.Get<SelectionComponentContext>().listViewClicked;
        List<string> _projectAssemblyList => TheModuler.Service.Get<SelectionComponentContext>().projectAssemblyList;
        ListView filteredView => TheModuler.Service.Get<ModulerContext>().filteredView;
        List<string> filteredlist => TheModuler.Service.Get<ModulerContext>().filteredList;
        ModulerLoading loading => TheModuler.Service.Get<ModulerLoading>();
        public void Start() {
            listViewClicked.Subscribe(i => {
                string n = _projectAssemblyList[i];
                for (int j = 0; j < filteredlist.Count; j++) {
                    if (filteredlist[j] == n) return;
                }
                filteredlist.Add(n);
                filteredView.Rebuild();
                loading.SaveFilteredAssemblies(filteredlist);
            });
        }
    }
}
