// ContextualButtonView.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\ContextualButtonView.csContextualButtonView.cs
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    /// только вид контекстуальных кнопок, ничего больше, скороее всего лишь статика будет
    public class ContextualButtonView {
        public static void SetStyle(VisualElement model) {
            SetStyle(model, 1, new Color(0.49f, 0.51f, 0.53f), 16);
        }
        static void SetStyle(VisualElement model, float width, Color color, float radius) {
            model.style.color = new Color(0.77f, 0.77f, 0.77f);
            model.style.fontSize = 15;
            StyleSheet.SetPadding(model, 5);
            model.style.paddingBottom = model.style.paddingTop = 5f;
            model.style.paddingLeft = model.style.paddingRight = 15f;
            StyleSheet.SetMargin(model, 5);
            StyleSheet.SetBorder_AsHigh(model);
            StyleSheet.BorderColor(model, color);
            StyleSheet.SetRadius(model, radius);
            model.style.backgroundColor = new Color(0.16f, 0.1f, 0.1f, 0.33f);
            model.style.width = new StyleLength(Length.Percent(94));
            model.style.alignSelf = Align.Center;
            HoverAnimation.DoOnlyTop(model);
        }
    }
}
