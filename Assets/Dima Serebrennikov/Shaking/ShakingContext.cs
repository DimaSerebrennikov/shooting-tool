using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class ShakingContext : IShakingContext, IPeriodicShakingContext {
        ShakingConfiguration _configuration;
        public ShakingContext(ShakingConfiguration configuration) {
            _configuration = configuration;
        }
        public Transform ObjectToManipulate => _configuration.ObjectToManipulate;
        public List<GravityDot> Dots { get; } = new();
        public Vector3 Velocity { get; set; }
        public float ForceToCenter => _configuration.ForceToCenter;
        public float Damping => _configuration.Damping;
        public Vector3 Center { get; set; }
        public float Timer { get; set; }
        public float TargetTimeBetweenShakes => _configuration.TargetTimeBetweenShakes;
        public float TimeBetweenShakes { get; set; }
        public float CoefToShake => _configuration.CoefToShake;
    }
}