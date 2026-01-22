using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
namespace Serebrennikov {
    class Moduler : EditorWindow {
        void CreateGUI() {
            Service service = TheModuler.Service;
            service.Get<ModulerContext>().rootVisualElement = rootVisualElement;
            service.Get<ModulerLoading>().Start();
            service.Get<ModularView>().Start();
            service.Get<ModulerListViewClient_Filtered>().Start();
            TheModuler.Bind_RemoveFromFilteredList(service.Get<ModulerContext>().filteredViewClicked, service.Get<ModulerController>());
            TheModuler.Bind_Rebuild(service.Get<ModulerContext>().filteredViewClicked, service.Get<ModulerContext>().filteredView);
            service.Get<ButtonView>().Start();
        }
        void OnDisable() {
            TheModuler.Service.Clear();
        }
    }
}
