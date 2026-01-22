using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    static class TheModuler {
        public static void Bind_Rebuild(Subject<int> filteredListViewClicked, ListView filteredView) {
            filteredListViewClicked.Subscribe(a => filteredView.Rebuild());
        }
        public static VisualElement CreateSeparator(float height) {
            VisualElement separator = new();
            separator.style.height = height;
            separator.style.backgroundColor = new Color(1f, 1f, 1f, 1f);
            separator.style.marginTop = 4;
            separator.style.marginBottom = 4;
            return separator;
        }
    }
}
