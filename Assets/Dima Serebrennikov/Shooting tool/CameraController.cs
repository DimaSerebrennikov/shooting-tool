using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class CameraController : MonoBehaviour {
        [SerializeField] HitSignal _hitSignalAsset;
        [SerializeField] Camera _cameraAsset;
        [SerializeField] ShakingParameters _configuration;
        Shaking_Decentralized _shakingDecentralized;
        Shaking _shaking;
        public bool IsSignaling = true;
        void Awake() {
            _hitSignalAsset = TheUnityObject.InstanceFromAsset(_hitSignalAsset);
            _cameraAsset = TheUnityObject.InstanceFromAsset(_cameraAsset);
            ShakingContext_Camera context = new(_cameraAsset.transform, _configuration);
            _shaking = new Shaking(context);
        }
        void Start() {
            _cameraAsset.transform.position = transform.position;
            _cameraAsset.transform.rotation = transform.rotation;
            _shaking.Start();
            _hitSignalAsset.Signal += a => {
                if (!IsSignaling) return;
                _shaking.Shake(_configuration.CoefToShake, _configuration.Duration);
            };
        }
        void Update() {
            _shaking.Update(Time.deltaTime);
        }
    }
}
