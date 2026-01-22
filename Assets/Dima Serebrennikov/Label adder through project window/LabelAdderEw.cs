// SimpleFloatingWindow.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\SimpleFloatingWindow.csSimpleFloatingWindow.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
/// Window containing:
/// - Add a written label to selected objects
/// - Remove all labels
/// - (future) Display available labels with option to open Project window
class LabelAdderEw : EditorWindow {
    TextField inputField;
    public void CreateGUI() {
        VisualElement root = rootVisualElement;
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
        Button addButton = new(() => TheLabelAdderAdding.AddLabelToSelection(inputField.value.Trim())) {
            text = "Add label to selection"
        };
        Button removeButton = new(TheLabelAdderRemoveAll.RemoveAllLabelsFromSelection) {
            text = "Remove all labels from selection"
        };
        root.Add(addButton);
        root.Add(removeButton);
    }
}
