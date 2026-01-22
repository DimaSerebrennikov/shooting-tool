using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public sealed class EnemyBulletState : MonoBehaviour {
        public readonly List<EnemyBulletCollision> Views = new(); /*entity = i*/
        public readonly List<float> Timers = new(); /*entity = i*/
    }
}
