// BoxElement.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxElement.csBoxElement.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public class BoxElementHud {
        public Label label { get; }
        public string labelText { get; }
        public string filePath { get; }
        public EnterableEvt isOpen { get; }
        public VisualElement visual { get; }
        public BoxElementHud(string labelText, string filePath, VisualElement visual) {
            this.labelText = labelText;
            this.filePath = filePath;
            this.visual = visual;
            label = new Label();
            isOpen = new EnterableEvt();
        }
        public void SetBoxElement() {
            visual.name = filePath;
            TheBoxStyleSheet.Set_Style(visual, new Color(0.49f, 0.51f, 0.53f), 16);
            TheBoxStyleSheet.Set_LabelView(labelText, label);
            visual.Add(label);
            visual.RegisterCallback<PointerUpEvent>(Callback);
            return;
            void Callback(PointerUpEvent evt) {
                ClickOnBoxElement(evt);
            }
        }
        public void ClickOnBoxElement(PointerUpEvent evt) {
            if (evt.button == 0) {
                evt.StopPropagation();
                if (isOpen.isActive) {
                    isOpen.Quit();
                } else {
                    isOpen.Enter(evt);
                }
            }
        }
    }
}
