// ParametersController.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Range enemy\ParametersController.csParametersController.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    class ParametersController : MonoBehaviour {
        [SerializeField] ShakingConfiguration _shakingConfiguration;
        [SerializeField] float _incrementDamping = 1f;
        [SerializeField] float _incrementForceToCenter = 1f;
        [SerializeField] float _incrementCoefToShake = 1f;
        void Update() {
            if (Input.GetKey(KeyCode.Q)) {
                _shakingConfiguration.Damping -= _incrementDamping * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W)) {
                _shakingConfiguration.Damping += _incrementDamping * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A)) {
                _shakingConfiguration.ForceToCenter -= _incrementForceToCenter * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S)) {
                _shakingConfiguration.ForceToCenter += _incrementForceToCenter * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Z)) {
                _shakingConfiguration.CoefToShake -= _incrementCoefToShake * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.X)) {
                _shakingConfiguration.CoefToShake += _incrementCoefToShake * Time.deltaTime;
            }
        }
    }
}
