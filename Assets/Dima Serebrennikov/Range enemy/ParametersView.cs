// ParametersView.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Range enemy\ParametersView.csParametersView.cs
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
namespace Serebrennikov {
    class ParametersView : MonoBehaviour {
        [SerializeField] ShakingConfiguration _shakingConfiguration;
        [SerializeField] TextMeshPro _damping;
        [SerializeField] TextMeshPro _forceToCenter;
        [SerializeField] TextMeshPro _shakePower;
        void Update() {
            _damping.text = Math.Round(_shakingConfiguration.Damping, 2).ToString();
            _forceToCenter.text = Math.Round(_shakingConfiguration.ForceToCenter, 2).ToString();
            _shakePower.text = Math.Round(_shakingConfiguration.CoefToShake, 2).ToString();
        }
    }
}
