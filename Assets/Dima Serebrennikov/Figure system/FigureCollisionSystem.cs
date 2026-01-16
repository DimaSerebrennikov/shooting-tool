using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class FigureCollisionSystem : IUpdate {
        List<FigureCollision> _figureCollision;
        List<FigureRevealingData> _revealed;
        List<Figure> _figure;
        CollisionWithFigureContext CollisionListAsset;
        public FigureCollisionSystem(List<FigureCollision> figureCollision, List<Figure> figure, List<FigureRevealingData> revealed, CollisionWithFigureContext collisionListAsset) {
            _figureCollision = figureCollision;
            _figure = figure;
            _revealed = revealed;
            CollisionListAsset = collisionListAsset;
        }
        public void Update() { /*Расскрывает фигуры, которые столкнулись с целевым объектом и от этого удаляет их из списка фигур. В конце очищает вписок колизий.*/
            _revealed.Clear();
            for (int i = 0; i < _figureCollision.Count; i++) {
                for (int j = 0; j < _figureCollision[i].Collisions.Count; j++) {
                    for (int k = 0; k < CollisionListAsset.List.Count; k++) {
                        Transform _target = CollisionListAsset.List[k];
                        if (_figureCollision[i].Collisions[j].Equals(_target)) {
                            FigureRevealingData reveal = new() {
                                Position = _figureCollision[i].Figure.Position,
                                Id = _figureCollision[i].Figure.Id
                            };
                            _revealed.Add(reveal);
                            _figure.Remove(_figureCollision[i].Figure);
                        }
                    }
                }
                _figureCollision[i].Collisions.Clear();
            }
        }
    }
}
