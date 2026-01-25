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
            _damping.text = TheOutput.RoundToThreeSignificantDigits(_shakingConfiguration.Damping).ToString();
            _forceToCenter.text = TheOutput.RoundToThreeSignificantDigits(_shakingConfiguration.ForceToCenter).ToString();
            _shakePower.text = TheOutput.RoundToThreeSignificantDigits(_shakingConfiguration.CoefToShake).ToString();
        }
    }
}
