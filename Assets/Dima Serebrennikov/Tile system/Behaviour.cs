using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov.Tiles.Systems {
    public class Behaviour : MonoBehaviour {
        [SerializeField] HudConfiguration _hudConfiguration;
        [SerializeField] Serialization _serialization;
        Data _data;
        Hud _hud;
        CompositeUpdate _composite;
        void Awake() {
            _data = new Data(_serialization);
            _hud = new Hud(_data, _hudConfiguration);
            _composite = new CompositeUpdate(
/**/new TileTracker(_data.TileSize, _data.TargetInstance, _data),
/**/new TileAroundTargetSystem(_data.Tile, _data),
/**/new Service<Tile>(_data.AddedTile, _data.RemovedTile, _data.Tile),
/**/new TileVisualizationSystem(_data.TileSize, _data.TilePrefab, _data.AddedTile, _data.RemovedTile));
        }
        void Start() {}
        void Update() {
            _composite.Update();
        }
    }
}
