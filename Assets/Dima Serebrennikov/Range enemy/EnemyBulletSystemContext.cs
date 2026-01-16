using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class EnemyBulletSystemContext : MonoBehaviour {
        public List<EnemyBullet> AddedBullets = new();
        public void Add(Vector3 position, Quaternion rotation) {
            EnemyBullet n = new(position, rotation);
            AddedBullets.Add(n);
        }
    }
}