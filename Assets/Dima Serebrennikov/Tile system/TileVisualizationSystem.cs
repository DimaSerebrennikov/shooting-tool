// TileVisualizationSystem.csC:\Feeble snow\Assets\Serebrennikov\Tile system\TileVisualizationSystem.csTileVisualizationSystem.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;
namespace Serebrennikov {
    public class TileVisualizationSystem : IUpdate {
        float _tileSize;
        GameObject _tilePrefab;
        List<Tile> _newTile;
        List<Tile> _missingTile;
        Dictionary<Tile, TileView> _view;
        public TileVisualizationSystem(float tileSize, GameObject tilePrefab, List<Tile> newTile, List<Tile> missingTile) {
            _tileSize = tileSize;
            _tilePrefab = tilePrefab;
            _newTile = newTile;
            _missingTile = missingTile;
            _view = new Dictionary<Tile, TileView>();
        }
        public void Update() {
            for (int i = 0; i < _missingTile.Count; i++) {
                if (!_view.TryGetValue(_missingTile[i], out TileView view)) continue;
                Object.Destroy(view.Instance);
                _view.Remove(_missingTile[i]);
            }
            for (int i = 0; i < _newTile.Count; i++) {
                TileView newTileView = new() {
                    Tile = _newTile[i],
                    Size = _tileSize
                };
                newTileView.Instance = Object.Instantiate(_tilePrefab, newTileView.ScenePosition(), _tilePrefab.transform.rotation);
                newTileView.Instance.transform.localScale = Vector3.one * _tileSize;
                _view.Add(newTileView.Tile, newTileView);
            }
        }
    }
}
