using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public struct Figure : IEquatable<Figure> {
        public Vector3 Position;
        public Tile Tile;
        public int Id;
        public static bool operator ==(Figure left, Figure right) => left.Id == right.Id;
        public static bool operator !=(Figure left, Figure right) => !(left == right);
        public bool Equals(Figure other) {
            return Id == other.Id;
        }
        public override bool Equals(object obj) {
            return obj is Figure other && Equals(other);
        }
        public override int GetHashCode() {
            return HashCode.Combine(Id);
        }
    }
}
