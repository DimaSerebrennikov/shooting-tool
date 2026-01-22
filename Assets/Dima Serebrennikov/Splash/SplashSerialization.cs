// SplashSerialization.csC:\GameDev\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\SplashSerialization.csSplashSerialization.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    [Serializable]
    public class SplashSerialization {
        [SerializeField] ParticleSystem _particleSystem;
        [SerializeField] ParticleSystemRenderer _particleSystemRenderer;
        public ParticleSystem ParticleSystem => _particleSystem;
        public ParticleSystemRenderer ParticleSystemRenderer => _particleSystemRenderer;
        public void Reset(GameObject gameObject) {
            _particleSystem = gameObject.GetComponent<ParticleSystem>();
            _particleSystemRenderer = gameObject.GetComponent<ParticleSystemRenderer>();
        }
    }
}
