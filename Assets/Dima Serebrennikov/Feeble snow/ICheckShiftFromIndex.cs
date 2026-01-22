using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
namespace Serebrennikov {
    public interface ICheckShiftFromIndex {
        Vector2Int curIndexTileSample { get; set; }
        Subject<Vector2Int> onShiftedToThisIndex { get; set; }
        Vector3 positionOnTile { get; set; }
        float size { get; set; }
    }
}
