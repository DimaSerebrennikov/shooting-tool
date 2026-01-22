using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class FigureData {
        public List<Figure> SavedFigure = new();
        public List<Figure> ActiveFigure = new();
        public List<Figure> AddedActiveFigure = new();
        public List<Figure> RemovedActiveFigure = new();
        public List<FigureCollision> FigureCollision = new();
        public List<FigureVisulization> AddedView = new();
    }
}
