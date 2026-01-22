// IMapSerialization.csC:\v12\Feeble snow\Assets\Serebrennikov\Feeble snow\IMapSerialization.csIMapSerialization.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public interface IMapSerialization {
        float size { get; set; }
        Transform target { get; set; }
        int howMuchEnemiesOnTile { get; }
    }
}
