// Tile.csC:\Feeble snow\Assets\Serebrennikov\Tile system\Tile.csTile.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public struct Tile : IEquatable<Tile> {
        public Vector2Int Position;
        public static bool operator ==(Tile left, Tile right) => left.Position == right.Position;
        public static bool operator !=(Tile left, Tile right) => !(left == right);
        public bool Equals(Tile other) {
            return Position.Equals(other.Position);
        }
        public override bool Equals(object obj) {
            return obj is Tile other && Equals(other);
        }
        public override int GetHashCode() {
            return Position.GetHashCode();
        }
    }
}
