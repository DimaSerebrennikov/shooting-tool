using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public interface IMapTick : ICheckShiftFromIndex {
        public Transform target { get; set; }
        Vector3 lastPosition { get; set; }
    }
}
