using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class AutoDestroy : MonoBehaviour {
        void Start() {
            Destroy(gameObject);
        }
    }
}
