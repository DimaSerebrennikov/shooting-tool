using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class TileManager_Old : IIndexPosition, IUpdate {
        TileAroundTargetSystem _aroundTarget;
        TileTracker _tracker;
        TileVisualizationSystem _visualization;
        Service<Tile> _service;
        public TileManager_Old(GameObject tilePrefab, float tileSize, Transform target, FigureContext ctx) {
            List<Tile> addedTile = ctx.AddedTile;
            List<Tile> removedTile = ctx.RemovedTile;
            List<Tile> tile = new();
            _tracker = new TileTracker(tileSize, target, this);
            _aroundTarget = new TileAroundTargetSystem(tile, this);
            _service = new Service<Tile>(addedTile, removedTile, tile);
            _visualization = new TileVisualizationSystem(tileSize, tilePrefab, addedTile, removedTile);
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
