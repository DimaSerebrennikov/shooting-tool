// PeriodicShaking_3D.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Shaking\PeriodicShaking_3D.csPeriodicShaking_3D.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Serebrennikov {
    public class PeriodicShaking_3D {
        Shaking_Decentralized _shakingDecentralized;
        IPeriodicShakingContext _context;
        IShakingContext _gravityShaking;
        public PeriodicShaking_3D(IPeriodicShakingContext context, IShakingContext gravityShaking) {
            _context = context;
            _gravityShaking = gravityShaking;
            _shakingDecentralized = new Shaking_Decentralized(gravityShaking);
        }
        public void Start() {
            _shakingDecentralized.Start();
        }
        public void Update(float dt) {
            _context.TimeBetweenShakes += dt;
            if (_context.TimeBetweenShakes > _context.TargetTimeBetweenShakes) {
                _context.TimeBetweenShakes = 0f;
                _shakingDecentralized.Shake(_gravityShaking.Dots, _gravityShaking.Timer, Random.value * _context.CoefToShake);
            }
            _shakingDecentralized.Update(dt);
        }
    }
}
