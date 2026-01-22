// FigureCreationSystem.csC:\Feeble snow\Assets\Serebrennikov\Figure system\FigureCreationSystem.csFigureCreationSystem.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Serebrennikov {
    public class FigureCreationSystem : IUpdate {
        float _size;
        List<Figure> _savedFigure;
        List<Tile> _addedTile;
        List<Tile> _executedTile;
        int _enemyListSize;
        int _idCounter;
        public FigureCreationSystem(float size, List<Figure> savedFigure, List<Tile> addedTile, int enemyListSize) {
            _size = size;
            _savedFigure = savedFigure;
            _addedTile = addedTile;
            _enemyListSize = enemyListSize;
            _executedTile = new List<Tile>();
            _idCounter = 0;
        }
        public void Update() {
            for (int i = 0; i < _addedTile.Count; i++) {
                if (_executedTile.Contains(_addedTile[i])) continue;
                _executedTile.Add(_addedTile[i]);
                for (int j = 0; j < _enemyListSize; j++) {
                    Figure figure = new() {
                        Position = RandomLocate(RealPosition(_addedTile[i].Position, _size), _size),
                        Tile = _addedTile[i],
                        Id = _idCounter++
                    };
                    _savedFigure.Add(figure);
                }
            }
        }
        Vector2 RealPosition(Vector2Int position, float size) {
            return new Vector2(position.x * size, position.y * size);
        }
        Vector3 RandomLocate(Vector2 center, float size) {
            Vector2 LeftDownCorner = new(center.x - size / 2f, center.y - size / 2f);
            Vector2 RightUpCorner = new(center.x + size / 2f, center.y + size / 2f);
            return VectorRandomFunction(LeftDownCorner, RightUpCorner);
        }
        Vector3 VectorRandomFunction(Vector2 sideA, Vector2 sideB) {
            return new Vector3(Random.Range(sideA.x, sideB.x), 0f, Random.Range(sideA.y, sideB.y));
        }
    }
}
