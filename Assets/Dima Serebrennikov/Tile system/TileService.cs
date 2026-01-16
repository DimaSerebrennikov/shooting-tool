// TileService.csC:\Feeble snow\Assets\Serebrennikov\Tile system\TileService.csTileService.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class Service<T> : IUpdate {
        List<T> _added;
        List<T> _removed;
        List<T> _previous;
        List<T> _current;
        public Service(List<T> added, List<T> removed, List<T> current) {
            _added = added;
            _removed = removed;
            _current = current;
            _previous = new();
        }
        public void Update() {
            _added.Clear();
            _removed.Clear();
            foreach (var item in _current) {
                if (!_previous.Exists(a => a.Equals(item))) _added.Add(item);
            }
            foreach (var item in _previous) {
                if (!_current.Exists(a => a.Equals(item))) _removed.Add(item);
            }
            _previous.Clear();
            _previous.AddRange(_current);
        }
    }
}
