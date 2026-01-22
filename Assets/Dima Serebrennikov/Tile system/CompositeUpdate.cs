// CompositeUpdate.csC:\Feeble snow\Assets\Serebrennikov\Tile system\CompositeUpdate.csCompositeUpdate.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class CompositeUpdate : IUpdate {
        IUpdate[] _components;
        public CompositeUpdate(params IUpdate[] components) {
            _components = components;
        }
        public void Update() {
            foreach (IUpdate n in _components) {
                n.Update();
            }
        }
    }
}
