using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Serebrennikov {
    public class PeriodicShaking {
        Shaking_Decentralized _shakingDecentralized;
        IPeriodicShakingContext _context;
        IShakingContext _gravityShaking;
        public PeriodicShaking(IPeriodicShakingContext context, IShakingContext gravityShaking) {
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
                _shakingDecentralized.Shake2D(_gravityShaking.Dots, _gravityShaking.Timer, Random.value * _context.CoefToShake, DirectionStyle.Y);
            }
            _shakingDecentralized.Update(dt);
        }
        public void Update(float dt, DirectionStyle style) {
            _context.TimeBetweenShakes += dt;
            if (_context.TimeBetweenShakes > _context.TargetTimeBetweenShakes) {
                _context.TimeBetweenShakes = 0f;
                _shakingDecentralized.Shake2D(_gravityShaking.Dots, _gravityShaking.Timer, Random.value * _context.CoefToShake, style);
            }
            _shakingDecentralized.Update(dt);
        }
    }
}
