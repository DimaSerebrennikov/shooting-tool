using System;
using System.Collections.Generic;
using System.IO;
using ModestTree;
using UnityEngine;
namespace Zenject {
    public class HashSetPool<T> : StaticMemoryPool<HashSet<T>> {
        public HashSetPool() {
            OnSpawnMethod = OnSpawned;
            OnDespawnedMethod = OnDespawned;
        }

        public static HashSetPool<T> Instance { get; } = new();

        static void OnSpawned(HashSet<T> items) {
            Assert.That(items.IsEmpty());
        }

        static void OnDespawned(HashSet<T> items) {
            items.Clear();
        }
    }
}
