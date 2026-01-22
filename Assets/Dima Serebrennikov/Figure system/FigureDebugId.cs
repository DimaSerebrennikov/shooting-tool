// FigureDebugId.csC:\Feeble snow\Assets\Serebrennikov\Figure system\FigureDebugId.csFigureDebugId.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class FigureDebugId : IUpdate {
        public List<Figure> ActiveFigure;
        public FigureDebugId(List<Figure> activeFigure) {
            ActiveFigure = activeFigure;
        }
        public void Update() {
            for (int i = 0; i < ActiveFigure.Count; i++) {
                Debug.Log(ActiveFigure[i].Id);
            }
        }
    }
}
