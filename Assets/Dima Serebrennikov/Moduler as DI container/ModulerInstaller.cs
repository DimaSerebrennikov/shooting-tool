using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
namespace Serebrennikov {
    class ModulerInstaller : Installer {
        public override void InstallBindings() {
            /* ---------- Filtered list ---------- */
            Container.BindInstance(new List<string>())
                .WithId("filteredList");
            Container.BindInstance(new ListView())
                .WithId("filteredView");
            Container.BindInstance(new Subject<int>())
                .WithId("filteredClicked");
            /* ---------- Assembly list ---------- */
            Container.BindInstance(new List<string>())
                .WithId("assemblyList");
            Container.BindInstance(new ListView())
                .WithId("assemblyView");
            Container.BindInstance(new Subject<int>())
                .WithId("assemblyClicked");
            /* ---------- Shared UI ---------- */
            Container.BindInstance(new VisualElement())
                .WithId("splitContainer");
            /* ---------- Core modules ---------- */
            Container.Bind<ModulerView>().AsSingle();
            Container.Bind<ModulerLoading>().AsSingle();
            Container.Bind<ModulerController>().AsSingle();
            Container.Bind<ModulerListViewClient_Filtered>().AsSingle();
            Container.Bind<ModulerListViewClient_Assembly>().AsSingle();
            Container.Bind<ProjectAssemblyController>().AsSingle();
            Container.Bind<ModulerSelectionView>().AsSingle();
            Container.Bind<SelectionComponentBinder>().AsSingle();
            Container.Bind<ButtonController>().AsSingle();
            Container.Bind<ButtonView>().AsSingle();
            Container.Bind<Button>().AsSingle();
            Container.Bind<ModulerEntryPoint>().AsSingle();
        }
    }
}
