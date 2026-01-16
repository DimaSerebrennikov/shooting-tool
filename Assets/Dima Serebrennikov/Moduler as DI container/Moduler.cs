using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
namespace Serebrennikov {
    class Moduler : EditorWindow {
        void CreateGUI() {
            DiContainer service = new();
            service.BindInstance(rootVisualElement).WithId("root");
            service.BindInstance(this);
            service.Install<ModulerInstaller>();
            ModulerEntryPoint entry = service.Resolve<ModulerEntryPoint>();
            entry.Initialize();
        }
    }
}
