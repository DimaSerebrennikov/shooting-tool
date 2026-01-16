using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
namespace Serebrennikov {
    public static class TheRng {
        public static float Unit() {
            return Random.Range(0f, 1f);
        }
        public static float Norm() {
            return Random.Range(-1f, 1f);
        }
    }
}