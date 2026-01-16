using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public interface ICreateNewTileAroundIndex : IGetCreateTile {
        Subject<List<ITile>> onUpdateListOfTiles { get; set; }
    }
}