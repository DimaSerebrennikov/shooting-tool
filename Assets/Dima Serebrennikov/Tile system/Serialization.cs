// Serialization.csC:\Feeble snow\Assets\Serebrennikov\Tile system\Serialization.csSerialization.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tiles.Systems {
    [Serializable]
    public class Serialization {
        public GameObject TilePrefab;
        public Transform TargetObject;
    }
}
