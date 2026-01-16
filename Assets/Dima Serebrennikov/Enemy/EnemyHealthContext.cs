using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class EnemyHealthContext : MonoBehaviour {
      public  Dictionary<GameObject, IHealth> EnemyHealth = new();
    }
}
