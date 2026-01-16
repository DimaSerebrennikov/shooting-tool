using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class BulletContext : MonoBehaviour {
        public Action<GameObject> OnTrigger { get; set; } = (_) => {};
    }
}