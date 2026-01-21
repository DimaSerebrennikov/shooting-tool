// CameraShaking.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Shooting tool\CameraShaking.csCameraShaking.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    class CameraShaking : MonoBehaviour {
        PeriodicShaking _periodicShaking;
        [SerializeField] ShakingConfiguration _configuration;
        void Awake() {
            ShakingContext context = new(_configuration);
            _periodicShaking = new PeriodicShaking(context, context);
        }
        void Start() {
            _periodicShaking.Start();
        }
        void Update() {
            _periodicShaking.Update(Time.deltaTime);
        }
    }
}
