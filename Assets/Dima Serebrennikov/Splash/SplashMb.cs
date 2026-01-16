// SplashMb.csC:\GameDev\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\SplashMb.csSplashMb.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class SplashMb : MonoBehaviour {
        [SerializeField] SplashSerialization _serialization;
        IDisposable d;
        public SplashParticleController splashParticleController;
        void Awake() {
            splashParticleController = new(_serialization);
        }
        void OnEnable() {
            d = Loop.Tick(splashParticleController.OnUpdate);
        }
        void OnDisable() {
            d.Dispose();
        }
        void Reset() {
            _serialization.Reset(gameObject);
        }
    }
}
