using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    [Serializable]
    public class ShakingParameters {
        [SerializeField] float _forceToCenter;
        [SerializeField] float _damping;
        [SerializeField] float _coefToShake;
        [SerializeField] float _duration = 0.1f;
        public float ForceToCenter {
            get => _forceToCenter;
            set => _forceToCenter = value;
        }
        public float Damping {
            get => _damping;
            set => _damping = value;
        }
        public float CoefToShake {
            get => _coefToShake;
            set => _coefToShake = value;
        }
        public float Duration {
            get => _duration;
            set => _duration = value;
        }
    }
}
