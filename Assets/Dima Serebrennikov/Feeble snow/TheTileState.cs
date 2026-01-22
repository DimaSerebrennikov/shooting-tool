// TileState.csC:\GameDev\Halette\Assets\SereDim\Script\Game\Cmd\PlayerSpecific\TileState.csTileState.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;
namespace Serebrennikov {
    public class TileState {
        IRecreateSavedTile _recreating;
        IGetCreateTile _getCreateTile;
        public TileState(IRecreateSavedTile recreating, IGetCreateTile getCreateTile) {
            _recreating = recreating;
            _getCreateTile = getCreateTile;
        }
        public ITile CreateTile(Vector2Int index) {
            if (_getCreateTile.tilesMap.TryGetValue(index, out ITile enviTile)) {
                if (!enviTile.IsExisting) {
                    RecreateSavedTile(enviTile, index);
                }
            } else {
                Create_NewTile(ref enviTile, index);
            }
            return enviTile;
        }
        public void RemoveTile(Vector2Int index) {
            if (!_recreating.tilesMap.TryGetValue(index, out ITile tile)) return;
            if (!tile.IsExisting) return;
            tile.IsExisting = false;
            Object.Destroy(tile.Instance);
            _recreating.existingTiles.Remove(tile);
        }
        public void PlayerSetDataTile(ITile enviTile, Vector2Int index) {
            GetAdjustedGameObject(enviTile, index);
            enviTile.IsExisting = true;
            enviTile.Size = _recreating.size;
            enviTile.IndexPosition = new Vector2Int(index.x, index.y);
            _recreating.onCreteTile.Execute(enviTile);
            _recreating.tilesMap.Add(index, enviTile);
            _recreating.existingTiles.Add(enviTile);
        }
        public void RecreateSavedTile(ITile enviTile, Vector2Int index) {
            GetAdjustedGameObject(enviTile, index);
            enviTile.IsExisting = true;
            _recreating.tilesMap[index] = enviTile;
            _recreating.existingTiles.Add(enviTile);
            _recreating.onRecreteTile.Execute(enviTile);
        }
        public void GetAdjustedGameObject(ITile enviTile, Vector2Int index) {
            GameObject gameObject = _recreating.getTileGameObject();
            enviTile.Instance = gameObject;
            enviTile.Instance.transform.position = new Vector3(_recreating.size * index.x, 0f, _recreating.size * index.y);
            enviTile.Instance.transform.localScale = new Vector3(_recreating.size, _recreating.size, _recreating.size);
        }
        public void Create_NewTile(ref ITile enviTile, Vector2Int index) {
            enviTile = _getCreateTile.getCreateTile();
            PlayerSetDataTile(enviTile, index);
        }
    }
}
