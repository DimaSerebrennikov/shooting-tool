// ToggleAttackSpeed.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Shooting tool\ToggleAttackSpeed.csToggleAttackSpeed.cs
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;
namespace Serebrennikov {
    class ToggleAttackSpeed : MonoBehaviour {
        [SerializeField] RangeEnemyConfiguration _enemyAsset;
        [SerializeField] Slider _slider;
        [SerializeField] TextMeshProUGUI _valueText;
        void Awake() {
            _enemyAsset = TheUnityObject.InstanceFromAsset(_enemyAsset);
            _slider.value = _enemyAsset.AttackSpeed;
            _valueText.text = Math.Round(_enemyAsset.AttackSpeed, 2).ToString();
            _slider.onValueChanged.AddListener(a => {
                _enemyAsset.SetAttackSpeedPersistent(_slider.value);
                _valueText.text = Math.Round(_enemyAsset.AttackSpeed, 2).ToString();
            });
        }
    }
}
