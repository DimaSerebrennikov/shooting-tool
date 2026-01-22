using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public interface IGetAdjustedGameObject {
        Func<GameObject> getTileGameObject { get; set; }
        float size { get; set; }
    }
}
