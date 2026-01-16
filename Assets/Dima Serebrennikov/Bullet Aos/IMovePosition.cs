using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal interface IMovePosition {
        Vector3 Direction { get; set; }
        float Speed { get; set; }
        Vector3 Position { get; set; }
        Vector3 Forward { get; set; }
    }
}