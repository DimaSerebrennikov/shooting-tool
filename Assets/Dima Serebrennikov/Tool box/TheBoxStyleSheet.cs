// BoxStyleSheet.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\BoxStyleSheet.csBoxStyleSheet.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    /// предоставляет стиль для объектов, которые находятся внутри Box
    public static class TheBoxStyleSheet {
        ///<param name="a">font which will stay on this label</param>
        public static void Set_LabelView(string text, Label model) {
            model.text = text;
            model.style.alignSelf = Align.Center;
            model.style.fontSize = 16;
        }
        ///<param name="a">style will be applied to this visual element</param>
        public static void Set_Style(VisualElement a, Color color, float radius) {
            a.style.marginBottom = 5;
            a.style.marginTop = 5;
            a.style.paddingBottom = 5;
            a.style.paddingTop = 5;
            a.style.fontSize = 15;
            StyleSheet.SetBorder_AsHigh(a);
            StyleSheet.BorderColor(a, color);
            StyleSheet.SetRadius(a, radius);
            a.style.backgroundColor = new Color(0.16f, 0.1f, 0.1f, 0.33f);
            a.style.width = new StyleLength(Length.Percent(94));
            a.style.alignSelf = Align.Center;
            HoverAnimation.DoOnlyTop(a);
        }
    }
}
