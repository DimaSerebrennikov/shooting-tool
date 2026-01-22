// FigureCollisionService.csC:\Feeble snow\Assets\Serebrennikov\Figure system\FigureCollisionService.csFigureCollisionService.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class FigureCollisionProvider : IUpdate {
        List<FigureVisulization> _addedView;
        List<FigureVisulization> _removedView;
        List<FigureCollision> _collision;
        public FigureCollisionProvider(List<FigureVisulization> addedView, List<FigureCollision> collision, List<FigureVisulization> removedView) {
            _addedView = addedView;
            _collision = collision;
            _removedView = removedView;
        }
        public void Update() {
            for (int i = 0; i < _removedView.Count; i++) {
                _collision.RemoveAll(c => c.Figure == _removedView[i].Figure);
            }
            for (int i = 0; i < _addedView.Count; i++) {
                FigureCollisionHook hook = _addedView[i].Instance.GetComponentInChildren<FigureCollisionHook>();
                FigureCollision figureCollision = new();
                figureCollision.Collisions = hook.Collisions;
                figureCollision.Figure = _addedView[i].Figure;
                _collision.Add(figureCollision);
            }
        }
    }
}
