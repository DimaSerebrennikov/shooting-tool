// ModularMenuItem.csC:\Feeble snow\Assets\Serebrennikov\Module manager\ModularMenuItem.csModularMenuItem.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal class ModularMenuItem {
        [MenuItem("Serebrennikov/Moduler as service")]
        static void Open() {
            EditorWindow.GetWindow<Moduler>("Moduler as service");
        }
    }
}
