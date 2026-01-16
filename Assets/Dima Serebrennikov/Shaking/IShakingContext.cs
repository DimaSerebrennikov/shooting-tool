using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public interface IShakingContext {
        Transform ObjectToManipulate { get; }
        List<GravityDot> Dots { get; }
        Vector3 Velocity { get; set; }
        float ForceToCenter { get; }
        float Damping { get; }
        Vector3 Center { get; set; }
        float Timer { get; set; }
    }
}
