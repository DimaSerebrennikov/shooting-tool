using System.Collections.Generic;
using UnityEngine;
namespace Serebrennikov {
    public class TileAroundTargetSystem : IUpdate {
        List<Tile> _tile;
        IIndexPosition _manager;
        public TileAroundTargetSystem(List<Tile> tile, IIndexPosition manager) {
            _tile = tile;
            _manager = manager;
        }
        public void Update() {
            int centerX = _manager.IndexPosition.x;
            int centerY = _manager.IndexPosition.y;
            const int distance = 1;
            _tile.Clear();
            for (int x = centerX - distance; x <= centerX + distance; x++)
            for (int y = centerY - distance; y <= centerY + distance; y++) {
                Vector2Int position = new(x, y);
                Tile item = new Tile();
                item.Position = new(x, y);
                _tile.Add(item);
            }
        }
    }
}
