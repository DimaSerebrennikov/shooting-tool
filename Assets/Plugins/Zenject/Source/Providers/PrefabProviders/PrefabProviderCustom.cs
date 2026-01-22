#if !NOT_UNITY3D

using System;
using System.Collections.Generic;
using System.IO;
using ModestTree;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Zenject {
    [NoReflectionBaking]
    public class PrefabProviderCustom : IPrefabProvider {
        readonly Func<InjectContext, Object> _getter;

        public PrefabProviderCustom(Func<InjectContext, Object> getter) {
            _getter = getter;
        }

        public Object GetPrefab(InjectContext context) {
            Object prefab = _getter(context);
            Assert.That(prefab != null, "Custom prefab provider returned null");
            return prefab;
        }
    }
}

#endif
