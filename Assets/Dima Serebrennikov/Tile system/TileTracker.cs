using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class TileTracker : IUpdate {
        Vector2 _position; /*Прошлая от обновления позиция*/
        Vector2 _positionOnTile; /*Только относительно тайла*/
        float _size;
        Transform _target;
        IIndexPosition _manager;
        public TileTracker(float size, Transform target, IIndexPosition manager) {
            _size = size;
            _target = target;
            _manager = manager;
        }
        public void Update() {
            Vector2 target = new(_target.position.x, _target.position.z);
            Vector2 traveled = target - _position;
            _positionOnTile += traveled;
            _position = target;
            CheckShiftFromIndex();
        }
        void ExecuteShifting(ref Vector2 aPositionOnTile, ref Vector2Int curIndexTileSample) {
            _positionOnTile = aPositionOnTile;
            _manager.IndexPosition = curIndexTileSample;
        }
        void CheckShiftFromIndex() {
            Vector2Int curIndexTileSample = _manager.IndexPosition;
            Vector2 aPositionOnTile = _positionOnTile;
            if (aPositionOnTile.x > _size / 2f) {
                curIndexTileSample.x += 1;
                aPositionOnTile.x -= _size;
                ExecuteShifting(ref aPositionOnTile, ref curIndexTileSample);
            } else if (aPositionOnTile.x < -_size / 2f) {
                curIndexTileSample.x -= 1;
                aPositionOnTile.x += _size;
                ExecuteShifting(ref aPositionOnTile, ref curIndexTileSample);
            } else if (aPositionOnTile.y > _size / 2f) {
                curIndexTileSample.y += 1;
                aPositionOnTile.y -= _size;
                ExecuteShifting(ref aPositionOnTile, ref curIndexTileSample);
            } else if (aPositionOnTile.y < -_size / 2f) {
                curIndexTileSample.y -= 1;
                aPositionOnTile.y += _size;
                ExecuteShifting(ref aPositionOnTile, ref curIndexTileSample);
            }
        }
    }
}
