// SelectionComponentContext.csC:\Feeble snow\Assets\Serebrennikov\Moduler as service\SelectionComponentContext.csSelectionComponentContext.cs
using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    class SelectionComponentContext {
        public List<string> projectAssemblyList = new();
        public ListView listView = new();
        public Subject<int> listViewClicked = new();
        public Button button = new();
    }
}
