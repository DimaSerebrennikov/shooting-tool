// Tiling.csC:\GameDev\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\Tiling.csTiling.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
namespace Serebrennikov {
    /// Создаёт карту из тайлов
    public class Tiling {
        IMap _map;
        TileState tileState;
        TileShiftTracker tracker;
        public Tiling(IMap map) {
            this._map = map;
            tileState = new(map, map);
            tracker = new(map);
        }
        public void CreateMap() {
            Loop.FTick(tracker);
            CreateNewTileAroundIndex(_map.curIndexTileSample);
            _map.onShiftedToThisIndex.Sub(CreateNewTileAroundIndex);
        }
        void CreateNewTileAroundIndex(Vector2Int indexOnMap) {
            int centerX = indexOnMap.x;
            int centerY = indexOnMap.y;
            const int distance = 2;
            CreateTilesAroundPoint(centerX, distance, centerY);
            SubstractOutsideTiles(centerX, distance, centerY);
            _map.onUpdateListOfTiles.Execute(_map.existingTiles);
        }
        void SubstractOutsideTiles(int centerX, int distance, int centerY) {
            for (int x = centerX - distance + 1; x <= centerX + distance - 1; x++) {
                tileState.RemoveTile(new Vector2Int(x, centerY + distance));
                tileState.RemoveTile(new Vector2Int(x, centerY - distance));
            }
            for (int y = centerY - distance + 1; y <= centerY + distance - 1; y++) {
                tileState.RemoveTile(new Vector2Int(centerX + distance, y));
                tileState.RemoveTile(new Vector2Int(centerX - distance, y));
            }
        }
        void CreateTilesAroundPoint(int centerX, int distance, int centerY) {
            for (int x = centerX - distance; x <= centerX + distance; x++) {
                for (int y = centerY - distance; y <= centerY + distance; y++) {
                    Vector2Int position = new(x, y);
                    tileState.CreateTile(new(x, y));
                }
            }
        }
    }
}
