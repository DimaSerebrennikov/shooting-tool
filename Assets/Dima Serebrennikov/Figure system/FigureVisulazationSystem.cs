// FigureVisulazationSystem.csC:\Feeble snow\Assets\Serebrennikov\Figure system\FigureVisulazationSystem.csFigureVisulazationSystem.cs
#region
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;
#endregion
namespace Serebrennikov {
    public class FigureVisulazationSystem : IUpdate {
        List<Figure> _addedActiveFigure;
        List<Figure> _removedActiveFigure;
        RandomComponentCreator _creator;
        Dictionary<int, FigureVisulization> _view;
        List<FigureVisulization> _addedView;
        List<FigureVisulization> _removedView;
        public FigureVisulazationSystem(List<Figure> addedActiveFigure, List<Figure> removedActiveFigure, RandomComponentCreator creator, List<FigureVisulization> addedView, List<FigureVisulization> removedView) {
            _addedActiveFigure = addedActiveFigure;
            _removedActiveFigure = removedActiveFigure;
            _creator = creator;
            _addedView = addedView;
            _removedView = removedView;
            _view = new Dictionary<int, FigureVisulization>();
        }
        public void Update() {
            _addedView.Clear();
            _removedView.Clear();
            for (int i = _addedActiveFigure.Count - 1; i >= 0; i--) {
                Figure figure = _addedActiveFigure[i];
                Component prefab = _creator.Get(figure.Id);
                Component instance = Object.Instantiate(prefab, figure.Position, Quaternion.identity);
                FigureVisulization newVisualization = new() {
                    Instance = instance,
                    Figure = figure
                };
                _view.Add(figure.Id, newVisualization);
                _addedView.Add(newVisualization);
            }
            for (int i = _removedActiveFigure.Count - 1; i >= 0; i--) {
                if (!_view.TryGetValue(_removedActiveFigure[i].Id, out FigureVisulization view)) continue;
                Object.Destroy(view.Instance.gameObject);
                _removedView.Add(view);
                _view.Remove(_removedActiveFigure[i].Id);
            }
        }
    }
}
