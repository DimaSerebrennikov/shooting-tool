// ShootingElementCreator.csC:\Feeble snow\Assets\Serebrennikov\Shooting tool\ShootingElementCreator.csShootingElementCreator.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;
namespace Serebrennikov {
    [Serializable]
    class ShootingElementCreator {
        [SerializeField] Transform _parent;
        [SerializeField] ShootingToolElement _prefab;
        public ShootingToolElement Add() {
            return Object.Instantiate(_prefab, _parent);
        }
    }
}
