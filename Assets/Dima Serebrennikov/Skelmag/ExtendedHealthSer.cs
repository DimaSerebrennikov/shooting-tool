// ExtendedHealthSo.csC:\Feeble snow\Assets\Serebrennikov\Skelmag\ExtendedHealthSo.csExtendedHealthSo.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    [Serializable]
    public class ExtendedHealthSer : IExtendedHealth {
        float _damageToTick;
        [SerializeField] float _normalTickDamage;
        [SerializeField] float _decaySpeed;
        public float damageToTick { get => _damageToTick; set => _damageToTick = value; }
        public float normalTickDamage => _normalTickDamage;
        public float decaySpeed => _decaySpeed;
    }
}
