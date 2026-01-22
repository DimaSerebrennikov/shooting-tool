using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    class ButtonView {
        Button _button => TheModuler.Service.Get<SelectionComponentContext>().button;
        VisualElement _root => TheModuler.Service.Get<ModulerContext>().rootVisualElement;
        ButtonController _controller => TheModuler.Service.Get<ButtonController>();
        public void Start() {
            _button.text = "Add new component";
            _root.Add(_button);
            _button.clicked += _controller.CreateSelectionComponent;
        }
    }
}
