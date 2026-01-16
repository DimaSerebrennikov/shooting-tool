using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal class BulletCollisionSystem {
        public BulletCollisionSystem(EnemyHealthContext enemyHealthContextAsset) {
            _enemyHealthContextAsset = enemyHealthContextAsset;
        }
        EnemyHealthContext _enemyHealthContextAsset;
        public void Collide(GameObject other) {
            _enemyHealthContextAsset.EnemyHealth.TryGetValue(other, out IHealth n);
            n?.Deal(1f);
        }
    }
}
