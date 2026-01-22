using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Zenject {
    public class SceneContextRegistryAdderAndRemover : IInitializable, IDisposable {
        readonly SceneContextRegistry _registry;
        readonly SceneContext _sceneContext;

        public SceneContextRegistryAdderAndRemover(
            SceneContext sceneContext,
            SceneContextRegistry registry) {
            _registry = registry;
            _sceneContext = sceneContext;
        }

        public void Initialize() {
            _registry.Add(_sceneContext);
        }

        public void Dispose() {
            _registry.Remove(_sceneContext);
        }
    }
}
