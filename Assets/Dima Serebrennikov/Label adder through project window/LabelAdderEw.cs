// SimpleFloatingWindow.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\SimpleFloatingWindow.csSimpleFloatingWindow.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;
/// Window containing:
/// - Add a written label to selected objects
/// - Remove all labels
/// - (future) Display available labels with option to open Project window
internal class LabelAdderEw : EditorWindow {
    TextField inputField;
    public void CreateGUI() {
        var root = rootVisualElement;
        TheLabelAdderStyle.Style(root);
        InputField(root);
        AddButtons(root);
        LabelAdderDisplay.Populate(root);
    }
    void InputField(VisualElement root) {
        inputField = TheLabelAdderStyle.NewInputField();
        root.Add(inputField);
    }
    void AddButtons(VisualElement root) {
        var addButton = new Button(() => TheLabelAdderAdding.AddLabelToSelection(inputField.value.Trim())) {
            text = "Add label to selection"
        };
        var removeButton = new Button(TheLabelAdderRemoveAll.RemoveAllLabelsFromSelection) {
            text = "Remove all labels from selection"
        };
        root.Add(addButton);
        root.Add(removeButton);
    }
}
