using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class EnemyHealthContext : MonoBehaviour {
        public Dictionary<GameObject, IHealth> EnemyHealth = new();
    }
}
