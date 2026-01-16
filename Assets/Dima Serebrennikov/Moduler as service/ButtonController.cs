using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    class ButtonController {
        ModulerListViewClient_Assembly _listStyle => TheModuler.Service.Get<ModulerListViewClient_Assembly>();
        ProjectAssemblyController _controller => TheModuler.Service.Get<ProjectAssemblyController>();
        ModulerSelectionView _view => TheModuler.Service.Get<ModulerSelectionView>();
        SelectionComponentBinder _binder => TheModuler.Service.Get<SelectionComponentBinder>();
        public void CreateSelectionComponent() {
            _listStyle.Start();
            _view.Start();
            _controller.Start();
            _binder.Start();
        }
    }
}
