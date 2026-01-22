// ModularMenuItem.csC:\Feeble snow\Assets\Serebrennikov\Module manager\ModularMenuItem.csModularMenuItem.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
namespace Serebrennikov {
    class ModularMenuItem {
        [MenuItem("Serebrennikov/Moduler")]
        static void Open() {
            EditorWindow.GetWindow<Moduler>("Moduler");
        }
    }
}
