// HoverAnimation.csC:\GameDev\Halette\Assets\SereDim\Script\Tool\Tul\HoverAnimation.csHoverAnimation.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    /// Provides hovering animations
    public class HoverAnimation {
        /// Will animate all objects under the cursor
        public static void Do(VisualElement element) {
            Color startColor = element.style.backgroundColor.value;
            Color hoveredColor = new(0.5f, 0.5f, 0.5f, 0.3f);
            element.style.transitionProperty = new List<StylePropertyName> {
                new("background-color")
            };
            element.style.transitionDuration = new List<TimeValue> {
                new(0.3f, TimeUnit.Second)
            };
            element.style.transitionTimingFunction = new List<EasingFunction> {
                new(EasingMode.EaseInOut)
            };
            element.RegisterCallback<PointerEnterEvent>(p => {
                element.style.backgroundColor = hoveredColor;
            });
            element.RegisterCallback<PointerLeaveEvent>(p => {
                element.style.backgroundColor = startColor;
            });
        }
        /// Will animate only top most covered visual element
        public static void DoOnlyTop(VisualElement element) {
            Color startColor = element.style.backgroundColor.value;
            Color hoveredColor = new(0.5f, 0.5f, 0.5f, 0.3f);
            element.style.transitionProperty = new List<StylePropertyName> {
                new("background-color")
            };
            element.style.transitionDuration = new List<TimeValue> {
                new(0.3f, TimeUnit.Second)
            };
            element.style.transitionTimingFunction = new List<EasingFunction> {
                new(EasingMode.EaseInOut)
            };
            element.RegisterCallback<MouseOverEvent>(p => {
                element.style.backgroundColor = hoveredColor;
                p.StopPropagation();
            });
            element.RegisterCallback<MouseOutEvent>(p => {
                element.style.backgroundColor = startColor;
                p.StopPropagation();
            });
        }
    }
}
