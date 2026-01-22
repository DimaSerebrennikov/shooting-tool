using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    class ButtonController {
        ModulerListView _listStyle;
        ProjectAssemblyController _controller;
        ModulerSelectionView _view;
        SelectionComponentBinder _binder;
        public ButtonController(ModulerListView listStyle, ProjectAssemblyController controller, ModulerSelectionView view, SelectionComponentBinder binder) {
            _listStyle = listStyle;
            _controller = controller;
            _view = view;
            _binder = binder;
        }
        public void CreateSelectionComponent() {
            _listStyle.Start();
            _view.Start();
            _controller.Start();
            _binder.Start();
        }
    }
}
