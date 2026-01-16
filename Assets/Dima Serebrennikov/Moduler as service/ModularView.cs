using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal class ModularView {
        VisualElement _splitContainer => TheModuler.Service.Get<ModulerContext>().splitContainer;
        ListView _filteredView => TheModuler.Service.Get<ModulerContext>().filteredView;
        VisualElement _rootVisualElement => TheModuler.Service.Get<ModulerContext>().rootVisualElement;
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
