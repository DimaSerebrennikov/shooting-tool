using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public struct FigureStyle {
        public readonly int Id;
        public readonly int Style;
        public FigureStyle(int id, int style) {
            Id = id;
            Style = style;
        }
    }
}