// RangeEnemyConfiguration.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Range enemy\RangeEnemyConfiguration.csRangeEnemyConfiguration.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class RangeEnemyConfiguration : MonoBehaviour {
        [SerializeField] float _savedAttackSpeed = 1f;
        public float AttackSpeed { get; private set; }
        void Awake() {
            AttackSpeed = PlayerPrefs.GetFloat(_attackSpeedKey, _savedAttackSpeed);
        }
        public void SetAttackSpeedPersistent(float value) {
            AttackSpeed = value;
            PlayerPrefs.SetFloat(_attackSpeedKey, value);
            _savedAttackSpeed = value;
        }
        public void SetAttackSpeedTemporary(float value) {
            AttackSpeed = value;
        }
        void OnValidate() {
            _savedAttackSpeed = PlayerPrefs.GetFloat(_attackSpeedKey, _savedAttackSpeed);
        }
        const string _attackSpeedKey = "RangeEnemy.AttackSpeed";
    }
}
