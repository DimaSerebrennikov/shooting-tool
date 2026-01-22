using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class TileSystem : MonoBehaviour, IIndexPosition, IUpdate {
        [SerializeField] GameObject tilePrefab;
        [SerializeField] Transform _targetAsset;
        [SerializeField] FigureContext _contextAsset;
        TileAroundTargetSystem _aroundTarget;
        TileTracker _tracker;
        TileVisualizationSystem _visualization;
        Service<Tile> _service;
        void Awake() {
            _contextAsset = TheUnityObject.InstanceFromAsset(_contextAsset);
            _targetAsset = TheUnityObject.InstanceFromAsset(_targetAsset);
            List<Tile> addedTile = _contextAsset.AddedTile;
            List<Tile> removedTile = _contextAsset.RemovedTile;
            List<Tile> tile = new();
            _tracker = new TileTracker(_contextAsset.TileSize, _targetAsset, this);
            _aroundTarget = new TileAroundTargetSystem(tile, this);
            _service = new Service<Tile>(addedTile, removedTile, tile);
            _visualization = new TileVisualizationSystem(_contextAsset.TileSize, tilePrefab, addedTile, removedTile);
        }
        public void Update() {
            _tracker.Update();
            _aroundTarget.Update();
            _service.Update();
            _visualization.Update();
        }
        public Vector2Int IndexPosition { get; set; }
    }
}
