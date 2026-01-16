using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class FigureEditor : IUpdate {
        FigureEditorConfiguration _configuration;
        FigureData _data;
        public FigureEditor(FigureEditorConfiguration configuration, FigureData data) {
            _configuration = configuration;
            _data = data;
        }
        public void Start() {
            _configuration.SavedFigure.SetLabelText("SavedFigure");
            _configuration.ActiveFigure.SetLabelText("ActiveFigure");
            _configuration.AddedActiveFigure.SetLabelText("AddedActiveFigure");
            _configuration.RemovedActiveFigure.SetLabelText("RemovedActiveFigure");
            _configuration.FigureCollision.SetLabelText("FigureCollision");
            _configuration.AddedView.SetLabelText("AddedView");
        }
        public void Update() {
            _configuration.SavedFigure.UpdateList(_data.SavedFigure);
            _configuration.ActiveFigure.UpdateList(_data.ActiveFigure);
            _configuration.AddedActiveFigure.UpdateList(_data.AddedActiveFigure);
            _configuration.RemovedActiveFigure.UpdateList(_data.RemovedActiveFigure);
            _configuration.FigureCollision.UpdateList(_data.FigureCollision);
            _configuration.AddedView.UpdateList(_data.AddedView);
        }
    }
}
