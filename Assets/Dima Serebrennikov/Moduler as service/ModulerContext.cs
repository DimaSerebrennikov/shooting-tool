// ModulerContext.csC:\Feeble snow\Assets\Serebrennikov\Moduler as service\ModulerContext.csModulerContext.cs
using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    class ModulerContext {
        public List<string> filteredList = new();
        public ListView filteredView = new();
        public VisualElement splitContainer = new();
        public Subject<int> filteredViewClicked = new();
        public VisualElement rootVisualElement;
    }
}
