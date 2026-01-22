// IGhost.csC:\v12\Feeble snow\Assets\Serebrennikov\Feeble snow\IGhost.csIGhost.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public interface IGhost {
        public int Style { get; set; }
        public Vector3 Position { get; set; }
        public ITile Tile { get; set; }
        public Subject OnRemove { get; set; }
    }
}
