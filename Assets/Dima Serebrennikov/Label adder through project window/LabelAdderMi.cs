// LabelAdderMi.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\LabelAdderMi.csLabelAdderMi.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
static class LabelAdderMi {
    [MenuItem("Serebrennikov/Label adder")]
    static void Do() {
        LabelAdderEw window = ScriptableObject.CreateInstance<LabelAdderEw>();
        window.titleContent = new GUIContent("Label adder");
        window.position = new Rect(300, 200, 200, 80);
        window.ShowUtility();
    }
}
