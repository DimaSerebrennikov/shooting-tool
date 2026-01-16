using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public struct TileView {
        public GameObject Instance;
        public Tile Tile;
        public float Size;
        public Vector2 RealPosition() {
            return new Vector2(Tile.Position.x * Size, Tile.Position.y * Size);
        }
        public Vector3 ScenePosition() {
            return new Vector3(Tile.Position.x * Size, 0f, Tile.Position.y * Size);
        }
    }
}
