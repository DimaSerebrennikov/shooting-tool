// ActiveFigureService.csC:\Feeble snow\Assets\Serebrennikov\Figure system\ActiveFigureService.csActiveFigureService.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class ActiveFigureProvider : IUpdate {
        List<Figure> _savedFigure;
        List<Figure> _activeFigure;
        List<Tile> _addedTile;
        List<Tile> _removedTile;
        public ActiveFigureProvider(List<Figure> savedFigure, List<Figure> activeFigure, List<Tile> addedTile, List<Tile> removedTile) {
            _savedFigure = savedFigure;
            _activeFigure = activeFigure;
            _addedTile = addedTile;
            _removedTile = removedTile;
        }
        public void Update() {
            for (int i = 0; i < _addedTile.Count; i++) {
                for (int j = 0; j < _savedFigure.Count; j++) {
                    if (_savedFigure[j].Tile == _addedTile[i]) {
                        _activeFigure.Add(_savedFigure[j]);
                    }
                }
            }
            for (int i = 0; i < _removedTile.Count; i++) {
                for (int j = 0; j < _savedFigure.Count; j++) {
                    if (_savedFigure[j].Tile == _removedTile[i]) {
                        _activeFigure.Remove(_savedFigure[j]);
                    }
                }
            }
            _activeFigure.RemoveAll(f => !_savedFigure.Contains(f));
        }
    }
}
