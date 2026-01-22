using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Zenject {
    public class ListPool<T> : StaticMemoryPool<List<T>> {
        public ListPool() {
            OnDespawnedMethod = OnDespawned;
        }

        public static ListPool<T> Instance { get; } = new();

        void OnDespawned(List<T> list) {
            list.Clear();
        }
    }
}
