// EnemiesOnTiles.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\EnemiesOnTiles.csEnemiesOnTiles.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Serebrennikov {
    public class GhostListOnTile {
        IFigureLocator figureLocator;
        public GhostListOnTile(IFigureLocator figureLocator) {
            this.figureLocator = figureLocator;
        }
        public IDisposable Wait() {
            return figureLocator.onLocateFiguresOnTile.Sub(LocateGhostsOnTile);
        }
        void LocateGhostsOnTile(ITile enviTile) {
            enviTile.Ghosts = new List<IGhost>();
            for (int i = 0; i < figureLocator.howMuchEnemiesOnTile; i++) {
                if (!figureLocator.Ghost(out IGhost newGhost)) continue;
                newGhost.Tile = enviTile;
                newGhost.Position = RandomLocate(newGhost.Tile);
                newGhost.OnRemove.Sub(() => enviTile.Ghosts.Remove(newGhost)); //Remove EnemyDot   from EnviTile list of dots 
                enviTile.Ghosts.Add(newGhost);
                figureLocator.onAfterCreateGhost.Execute(newGhost);
            }
        }
        static Vector3 RandomLocate(ITile enviTile) {
            Vector2 center = new(enviTile.IndexPosition.x * enviTile.Size, enviTile.IndexPosition.y * enviTile.Size);
            Vector2 LeftDownCorner = new(center.x - enviTile.Size / 2f, center.y - enviTile.Size / 2f);
            Vector2 RightUpCorner = new(center.x + enviTile.Size / 2f, center.y + enviTile.Size / 2f);
            Vector2 randomPosition = VectorRandomFunction(LeftDownCorner, RightUpCorner);
            return new Vector3(randomPosition.x, 0f, randomPosition.y);
        }
        static Vector2 VectorRandomFunction(Vector2 a, Vector2 b) {
            return new Vector2(Random.Range(a.x, b.x), Random.Range(a.y, b.y));
        }
    }
}
