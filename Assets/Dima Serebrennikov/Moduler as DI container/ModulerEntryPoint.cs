using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
namespace Serebrennikov {
    class ModulerEntryPoint {
        readonly ModulerLoading _loading;
        readonly ModulerView _view;
        readonly ModulerListViewClient_Filtered _filteredListView;
        readonly ButtonView _buttonView;
        readonly ModulerController _controller;
        public ModulerEntryPoint(
            ModulerLoading loading,
            ModulerView view,
            ModulerListViewClient_Filtered filteredListView,
            ButtonView buttonView, ModulerController controller) {
            _loading = loading;
            _view = view;
            _filteredListView = filteredListView;
            _buttonView = buttonView;
            _controller = controller;
        }
        public void Initialize() {
            _loading.Start();
            _view.Start();
            _controller.Start();
            _filteredListView.Start();
            _buttonView.Start();
        }
    }
}
