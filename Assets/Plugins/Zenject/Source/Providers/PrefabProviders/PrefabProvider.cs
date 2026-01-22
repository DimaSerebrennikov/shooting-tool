#if !NOT_UNITY3D

using System;
using System.Collections.Generic;
using System.IO;
using ModestTree;
using UnityEngine;
using Object = UnityEngine.Object;
namespace Zenject {
    [NoReflectionBaking]
    public class PrefabProvider : IPrefabProvider {
        readonly Object _prefab;

        public PrefabProvider(Object prefab) {
            Assert.IsNotNull(prefab);
            _prefab = prefab;
        }

        public Object GetPrefab(InjectContext _) {
            return _prefab;
        }
    }
}

#endif
