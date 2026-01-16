using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
namespace Serebrennikov {
    class ModulerView {
        VisualElement _splitContainer;
        ListView _filteredView;
        VisualElement _rootVisualElement;
        public ModulerView(
            [Inject(Id = "splitContainer")] VisualElement splitContainer,
            [Inject(Id = "filteredView")] ListView filteredView,
            [Inject(Id = "root")] VisualElement rootVisualElement) {
            _splitContainer = splitContainer;
            _filteredView = filteredView;
            _rootVisualElement = rootVisualElement;
        }
        public void Start() {
            _splitContainer.style.flexDirection = FlexDirection.Column;
            _splitContainer.style.flexGrow = 1;
            _filteredView.style.flexGrow = 1;
            _filteredView.style.flexBasis = 0;
            _splitContainer.Add(_filteredView);
            _rootVisualElement.Add(_splitContainer);
        }
    }
}
