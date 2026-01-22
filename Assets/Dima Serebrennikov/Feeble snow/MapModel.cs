// MapData.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\MapData.csMapData.cs
using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
namespace Serebrennikov {
    public class MapModel : IMap {
        IMapSerialization _serialization;
        public Func<GameObject> getTileGameObject { get; set; }
        public Func<ITile> getCreateTile { get; set; }
        public MapModel(IMapSerialization serialization, Func<GameObject> getTileGameObject, Func<ITile> getCreateTile) {
            _serialization = serialization;
            this.getTileGameObject = getTileGameObject;
            this.getCreateTile = getCreateTile;
        }
        public Vector2Int curIndexTileSample { get; set; }
        public Subject<Vector2Int> onShiftedToThisIndex { get; set; } = new();
        public Vector3 positionOnTile { get; set; }
        public float size { get => _serialization.size; set => _serialization.size = value; }
        public Transform target { get => _serialization.target; set => _serialization.target = value; }
        public Vector3 lastPosition { get; set; }
        public Subject<ITile> onCreteTile { get; set; } = new();
        public Dictionary<Vector2Int, ITile> tilesMap { get; set; } = new();
        public List<ITile> existingTiles { get; set; } = new();
        public Subject<ITile> onRecreteTile { get; set; } = new();
        public Subject<List<ITile>> onUpdateListOfTiles { get; set; } = new();
    }
}
