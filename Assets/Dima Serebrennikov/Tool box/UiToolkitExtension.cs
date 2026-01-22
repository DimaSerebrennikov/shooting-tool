// UiToolkitExtension.csC:\GameDev\Halette\Assets\SereDim\Script\Tool\Tul\UiToolkitExtension.csUiToolkitExtension.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public static class UiToolkitExtension {
        public static void TryRemove(this VisualElement parent, VisualElement child) {
            if (child != null && parent.Contains(child)) parent.Remove(child);
        }
    }
}
