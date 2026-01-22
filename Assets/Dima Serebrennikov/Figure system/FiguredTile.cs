using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public struct FiguredTile {
        public Vector2Int Position;
        public readonly List<FigureTransform> FigureList;
        public FiguredTile(List<FigureTransform> figureList, Vector2Int position) {
            FigureList = figureList;
            Position = position;
        }
    }
}
