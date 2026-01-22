using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
namespace Serebrennikov {
    public interface IRecreateSavedTile : ISetPlayerData {
        Subject<ITile> onRecreteTile { get; set; }
    }
}
