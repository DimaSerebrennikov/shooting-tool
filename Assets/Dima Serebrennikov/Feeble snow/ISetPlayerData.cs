using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public interface ISetPlayerData : IGetAdjustedGameObject {
        Subject<ITile> onCreteTile { get; set; }
        Dictionary<Vector2Int, ITile> tilesMap { get; set; }
        List<ITile> existingTiles { get; set; }
    }
}