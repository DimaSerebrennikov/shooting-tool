#if !NOT_UNITY3D

using System;
using System.Collections.Generic;
using System.IO;
using ModestTree;
using UnityEngine;
using Object = UnityEngine.Object;
namespace Zenject {
    [NoReflectionBaking]
    public class PrefabProviderResource : IPrefabProvider {
        readonly string _resourcePath;

        public PrefabProviderResource(string resourcePath) {
            _resourcePath = resourcePath;
        }

        public Object GetPrefab(InjectContext context) {
            GameObject prefab = (GameObject)Resources.Load(_resourcePath);
            Assert.That(prefab != null,
                "Expected to find prefab at resource path '{0}'", _resourcePath);
            return prefab;
        }
    }
}

#endif
