using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    [CreateAssetMenu(fileName = "MinMaxConfiguration", menuName = "Serebrennikov/MinMaxConfiguration")]
    class MinMaxConfiguration : ScriptableObject {
        public float Min;
        public float Max;
    }
}
