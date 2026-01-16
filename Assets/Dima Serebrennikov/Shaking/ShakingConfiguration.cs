using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class ShakingConfiguration : MonoBehaviour {
        [SerializeField] Transform _objectToManipulate;
        [SerializeField] float _forceToCenter;
        [SerializeField] float _damping;
        [SerializeField] float _targetTimeBetweenShakes;
        [SerializeField] float _coefToShake;
        public Transform ObjectToManipulate {
            get => _objectToManipulate;
            set => _objectToManipulate = value;
        }
        public float ForceToCenter {
            get => _forceToCenter;
            set => _forceToCenter = value;
        }
        public float Damping {
            get => _damping;
            set => _damping = value;
        }
    public float TargetTimeBetweenShakes {
            get => _targetTimeBetweenShakes;
            set => _targetTimeBetweenShakes = value;
        }
        public float CoefToShake {
            get => _coefToShake;
            set => _coefToShake = value;
        }
    }
}
