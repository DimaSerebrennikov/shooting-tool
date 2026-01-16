using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
namespace Serebrennikov {
    class SelectionComponentBinder {
        Subject<int> listViewClicked;
        List<string> _assembliesList;
        ListView filteredView;
        List<string> filteredlist;
        ModulerLoading loading;
        public SelectionComponentBinder(
            [Inject(Id = "assemblyClicked")] Subject<int> listViewClicked,
            [Inject(Id = "assemblyList")] List<string> assembliesList,
            [Inject(Id = "filteredView")] ListView filteredView,
            [Inject(Id = "filteredList")] List<string> filteredlist,
            ModulerLoading loading) {
            this.listViewClicked = listViewClicked;
            _assembliesList = assembliesList;
            this.filteredView = filteredView;
            this.filteredlist = filteredlist;
            this.loading = loading;
        }
        public void Start() {
            listViewClicked.Subscribe(i => {
                string n = _assembliesList[i];
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
