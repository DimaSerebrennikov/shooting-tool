// Configuration.csC:\Feeble snow\Assets\Serebrennikov\Tile system\Configuration.csConfiguration.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tiles.Systems {
    public class Data : IIndexPosition {
        public Data(Serialization serialization) {
            TilePrefab = serialization.TilePrefab;
            TargetInstance = TheUnityObject.Instance(serialization.TargetObject);
            Tile = new();
            AddedTile = new();
            RemovedTile = new();
        }
        public readonly GameObject TilePrefab;
        public readonly Transform TargetInstance;
        public readonly List<Tile> Tile;
        public readonly List<Tile> AddedTile;
        public readonly List<Tile> RemovedTile;
        public Vector2Int IndexPosition { get; set; }
        public float TileSize = 4f;
    }
}
