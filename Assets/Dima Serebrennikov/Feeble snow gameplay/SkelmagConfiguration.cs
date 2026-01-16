// Skelmag.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\Skelmag.csSkelmag.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    /// Это сериализация Skelmag, чтобы он мог получить конфигурацию с редактора.
    public class SkelmagConfiguration : MonoBehaviour {
        [SerializeField] SkelmagSer _ser;
        [SerializeField] Transform _hands;
        [SerializeField] Animator _animator;
        [SerializeField] PlayerHealthContext _playerHealthContextPacked;
        [SerializeField] Transform _barrelSpot;
        [SerializeField] TransformConfiguration _barrelConfigurationAsset;
        [SerializeField] LimitedValueContext _healthComponent;
        public SkelmagSer Ser { get => _ser; set => _ser = value; }
        public Transform Hands { get => _hands; set => _hands = value; }
        public Transform Barrel => _barrelSpot;
        public Animator Animator { get => _animator; set => _animator = value; }
        public PlayerHealthContext HealthContext { get; set; }
        public LimitedValueContext HealthComponent { get => _healthComponent; set => _healthComponent = value; }
        void Awake() {
            HealthContext = TheUnityObject.InstanceFromAsset(_playerHealthContextPacked);
            _barrelConfigurationAsset = TheUnityObject.InstanceFromAsset(_barrelConfigurationAsset);
            _barrelConfigurationAsset.Barrel = Barrel;
        }
    }
}
