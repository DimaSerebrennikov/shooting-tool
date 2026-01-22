using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class BulletContext : MonoBehaviour {
        public Action<GameObject> OnTrigger { get; set; } = _ => {};
    }
}
