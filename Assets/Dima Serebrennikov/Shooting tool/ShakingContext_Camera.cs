// ShakingContext_Camera.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Shooting tool\ShakingContext_Camera.csShakingContext_Camera.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class ShakingContext_Camera : IShakingContext {
        ShakingParameters _configuration;
        public Transform ObjectToManipulate { get; }
        public List<GravityDot> Dots { get; } = new();
        public Vector3 Center { get; set; }
        public float Timer { get; set; }
        public Vector3 Velocity { get; set; }
        public ShakingContext_Camera(Transform objectToManipulate, ShakingParameters configuration) {
            ObjectToManipulate = objectToManipulate;
            _configuration = configuration;
        }
        public float ForceToCenter => _configuration.ForceToCenter;
        public float Damping => _configuration.Damping;
    }
}
