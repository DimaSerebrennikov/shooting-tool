// FigureConfiguration.csC:\Feeble snow\Assets\Serebrennikov\Tile system\FigureConfiguration.csFigureConfiguration.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class FigureContext : MonoBehaviour {
        public RandomComponentCreator RandomComponentCreator;
        public float TileSize;
        public CollisionWithFigureContext CollisionListAsset;
        public int FigureNumberOnTile;
        [NonSerialized] public List<Tile> AddedTile = new();
        [NonSerialized] public List<Tile> RemovedTile = new();
        [NonSerialized] public List<FigureRevealingData> Revealed = new();
        void Awake() {
            CollisionListAsset = TheUnityObject.InstanceFromAsset(CollisionListAsset);
            RandomComponentCreator = TheUnityObject.InstanceFromAsset(RandomComponentCreator);
        }
    }
}
