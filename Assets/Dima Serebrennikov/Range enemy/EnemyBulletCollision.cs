using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class EnemyBulletCollision : MonoBehaviour {
        public BulletTrailDestructor Destructor;
        public Rigidbody Rb;
        public List<Transform> Collisions = new();
        void OnCollisionEnter(Collision other) {
            Collisions.Add(other.transform);
        }
        void OnTriggerEnter(Collider other) {
            Collisions.Add(other.transform);
        }
    }
}
