// TileShiftTracker.csC:\GameDev\Halette\Assets\SereDim\Script\Game\Cmd\PlayerSpecific\TileShiftTracker.csTileShiftTracker.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class TileShiftTracker : IFixedTick {
        IMapTick a;
        public TileShiftTracker(IMapTick a) {
            this.a = a;
        }
        public void FTick() {
            Vector3 newPosition = a.target.position;
            a.positionOnTile += newPosition - a.lastPosition;
            a.lastPosition = newPosition;
            CheckShiftFromIndex();
        }
        void ExecuteShifting(ref Vector3 aPositionOnTile, ref Vector2Int curIndexTileSample) {
            a.positionOnTile = aPositionOnTile;
            a.curIndexTileSample = curIndexTileSample;
            a.onShiftedToThisIndex.Execute(curIndexTileSample);
        }
        void CheckShiftFromIndex() {
            Vector2Int curIndexTileSample = a.curIndexTileSample;
            Vector3 aPositionOnTile = a.positionOnTile;
            if (aPositionOnTile.x > a.size / 2f) {
                curIndexTileSample.x += 1;
                aPositionOnTile.x -= a.size;
                ExecuteShifting(ref aPositionOnTile, ref curIndexTileSample);
            } else if (aPositionOnTile.x < -a.size / 2f) {
                curIndexTileSample.x -= 1;
                aPositionOnTile.x += a.size;
                ExecuteShifting(ref aPositionOnTile, ref curIndexTileSample);
            } else if (aPositionOnTile.z > a.size / 2f) {
                curIndexTileSample.y += 1;
                aPositionOnTile.z -= a.size;
                ExecuteShifting(ref aPositionOnTile, ref curIndexTileSample);
            } else if (aPositionOnTile.z < -a.size / 2f) {
                curIndexTileSample.y -= 1;
                aPositionOnTile.z += a.size;
                ExecuteShifting(ref aPositionOnTile, ref curIndexTileSample);
            }
        }
    }
}
