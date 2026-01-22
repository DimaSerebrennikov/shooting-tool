using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public interface IGetCreateTile : IRecreateSavedTile {
        Func<ITile> getCreateTile { get; set; }
    }
}
