using System;
using System.Collections.Generic;
using System.IO;
using ModestTree;
using UnityEngine;
namespace Zenject {
    public class DictionaryPool<TKey, TValue> : StaticMemoryPool<Dictionary<TKey, TValue>> {
        public DictionaryPool() {
            OnSpawnMethod = OnSpawned;
            OnDespawnedMethod = OnDespawned;
        }

        public static DictionaryPool<TKey, TValue> Instance { get; } = new();

        static void OnSpawned(Dictionary<TKey, TValue> items) {
            Assert.That(items.IsEmpty());
        }

        static void OnDespawned(Dictionary<TKey, TValue> items) {
            items.Clear();
        }
    }
}
