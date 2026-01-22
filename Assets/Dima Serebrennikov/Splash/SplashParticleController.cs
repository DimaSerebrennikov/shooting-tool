// SplashParticleController.csC:\GameDev\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\SplashParticleController.csSplashParticleController.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class SplashParticleController {
        SplashSerialization _serialization;
        static readonly int ColorShader = Shader.PropertyToID("_Color");
        Action onDestroy;
        bool _willDestroy;
        public SplashParticleController(SplashSerialization serialization) {
            _serialization = serialization;
        }
        public void ChangeColor(Color color) {
            _serialization.ParticleSystemRenderer.materials[0].SetColor(ColorShader, color);
            _serialization.ParticleSystemRenderer.materials[1].SetColor(ColorShader, color);
        }
        public void Play() {
            _serialization.ParticleSystem.Play();
            Stop();
        }
        public void Stop() {
            _willDestroy = true;
        }
        public void OnUpdate() {
            if (!_serialization.ParticleSystem.isPlaying && _willDestroy) {
                onDestroy?.Invoke();
            }
        }
    }
}
