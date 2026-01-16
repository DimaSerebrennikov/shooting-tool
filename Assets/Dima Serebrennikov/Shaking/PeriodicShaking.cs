using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
namespace Serebrennikov {
    public class PeriodicShaking {
        Shaking _shaking;
        IPeriodicShakingContext _context;
        IShakingContext _gravityShaking;
        public PeriodicShaking(IPeriodicShakingContext context, IShakingContext gravityShaking) {
            _context = context;
            _gravityShaking = gravityShaking;
            _shaking = new Shaking(gravityShaking);
        }
        public void Start() {
            _shaking.Start();
        }
        public void Update(float dt) {
            _context.TimeBetweenShakes += dt;
            if (_context.TimeBetweenShakes > _context.TargetTimeBetweenShakes) {
                _context.TimeBetweenShakes = 0f;
                _shaking.Shake2D(_gravityShaking.Dots, _gravityShaking.Timer, Random.value * _context.CoefToShake, DirectionStyle.Y);
            }
            _shaking.Update(dt);
        }
    }
}
