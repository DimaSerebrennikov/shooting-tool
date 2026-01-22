// ShootingToolElement.csC:\Feeble snow\Assets\Serebrennikov\Shooting tool\ShootingToolElement.csShootingToolElement.cs
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;
namespace Serebrennikov {
    class ShootingToolElement : MonoBehaviour {
        [SerializeField] Slider _slider;
        [SerializeField] TextMeshProUGUI _tmp;
        [SerializeField] TextMeshProUGUI _name;
        public Slider Slider { get => _slider; set => _slider = value; }
        public TextMeshProUGUI Tmp { get => _tmp; set => _tmp = value; }
        public TextMeshProUGUI Name { get => _name; set => _name = value; }
    }
}
