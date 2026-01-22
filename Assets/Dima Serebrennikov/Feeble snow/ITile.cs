// ITile.csC:\v12\Feeble snow\Assets\Serebrennikov\Feeble snow\ITile.csITile.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public interface ITile {
        public Vector2Int IndexPosition { get; set; }
        public bool IsExisting { get; set; }
        public List<IGhost> Ghosts { get; set; }
        public GameObject Instance { get; set; }
        public float Size { get; set; }
    }
}
