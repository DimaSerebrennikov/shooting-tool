using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public struct EnemyBullet {
        public Vector3 Position;
        public Quaternion Rotation;
        public EnemyBullet(Vector3 position, Quaternion rotation) {
            Position = position;
            Rotation = rotation;
        }
    }
}
