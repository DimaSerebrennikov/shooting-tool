// TileContext.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Figure system\TileContext.csTileContext.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class TileContext : MonoBehaviour {
        public float TileSize;
        public List<Tile> AddedTile;
        public List<Tile> RemovedTile;
        public int FigureNumberOnTile;
        public List<FigureRevealingData> Revealed;
    }
}
