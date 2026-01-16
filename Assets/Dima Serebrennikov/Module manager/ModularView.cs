using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal class ModularView {
        VisualElement _splitContainer;
        ListView _filteredView;
        VisualElement _rootVisualElement;
        public ModularView(VisualElement splitContainer, ListView filteredView, VisualElement rootVisualElement) {
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
