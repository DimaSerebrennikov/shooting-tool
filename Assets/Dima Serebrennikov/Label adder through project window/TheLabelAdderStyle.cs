// TheLabelAdderStyle.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\TheLabelAdderStyle.csTheLabelAdderStyle.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
static class TheLabelAdderStyle {
    static internal void Style(VisualElement root) {
        root.style.flexDirection = FlexDirection.Column;
        root.style.paddingTop = 6;
        root.style.paddingLeft = 6;
        root.style.paddingRight = 6;
        root.style.paddingBottom = 6;
    }
    static internal TextField NewInputField() {
        TextField inputField = new("Label:");
        inputField.style.marginBottom = 6;
        return inputField;
    }
}
