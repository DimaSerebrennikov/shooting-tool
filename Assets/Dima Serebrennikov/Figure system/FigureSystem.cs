// FigureManager.csC:\Feeble snow\Assets\Serebrennikov\Figure system\FigureManager.csFigureManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class FigureSystem : MonoBehaviour {
        [SerializeField] TileContext _contextAsset;
        [SerializeField] FigureContext2 _context2Asset;
        IUpdate _update;
        void Awake() {
            _contextAsset = TheUnityObject.InstanceFromAsset(_contextAsset);
            _context2Asset = TheUnityObject.InstanceFromAsset(_context2Asset);
            List<FigureVisulization> removedView = new();
            FigureData data = new();
            _update = new CompositeUpdate(
                new FigureCreationSystem(
                    _contextAsset.TileSize,
                    data.SavedFigure,
                    _contextAsset.AddedTile,
                    _contextAsset.FigureNumberOnTile),
                new ActiveFigureProvider(
                    data.SavedFigure,
                    data.ActiveFigure,
                    _contextAsset.AddedTile,
                    _contextAsset.RemovedTile),
                new Service<Figure>(
                    data.AddedActiveFigure,
                    data.RemovedActiveFigure,
                    data.ActiveFigure),
                new FigureVisulazationSystem(
                    data.AddedActiveFigure,
                    data.RemovedActiveFigure,
                    _context2Asset.RandomComponentCreator,
                    data.AddedView,
                    removedView),
                new FigureCollisionProvider(
                    data.AddedView,
                    data.FigureCollision,
                    removedView),
                new FigureCollisionSystem(
                    data.FigureCollision,
                    data.SavedFigure,
                    _contextAsset.Revealed,
                    _context2Asset.CollisionListAsset));
        }
        public void Update() {
            _update.Update();
        }
    }
}
