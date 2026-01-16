using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public struct GravityDot {
        public GravityDot(Vector3 direction, Func<float, float> curve, float fromTime, float duration, float force) {
            Direction = direction;
            Curve = curve;
            FromTime = fromTime;
            Duration = duration;
            Force = force;
        }
        public Vector3 Direction;
        public Func<float, float> Curve;
        public float FromTime;
        public float Duration;
        public float Force;
    }
}