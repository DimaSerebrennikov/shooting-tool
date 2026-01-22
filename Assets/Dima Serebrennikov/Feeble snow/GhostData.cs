using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class GhostData : IGhost {
        public int Style { get; set; }
        public Vector3 Position { get; set; }
        public ITile Tile { get; set; }
        public IFigure GameObjectSample { get; set; }
        public Subject OnRemove { get; set; } = new();
    }
}
