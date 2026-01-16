using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal class ButtonView {
        Button _button;
        VisualElement _root;
        ButtonController _controller;
        public ButtonView(Button button, VisualElement root, ButtonController controller) {
            _button = button;
            _root = root;
            _controller = controller;
        }
        public void Start() {
            _button.text = "Add new component";
            _root.Add(_button);
            _button.clicked += _controller.CreateSelectionComponent;
        }
    }
}