// FigureContext2.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Figure system\FigureContext2.csFigureContext2.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class FigureContext2 : MonoBehaviour {
        public RandomComponentCreator RandomComponentCreator;
        public CollisionWithFigureContext CollisionListAsset;
        void Awake() {
            CollisionListAsset = TheUnityObject.InstanceFromAsset(CollisionListAsset);
            RandomComponentCreator = TheUnityObject.InstanceFromAsset(RandomComponentCreator);
        }
    }
}
