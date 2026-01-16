using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    /// 
    public interface IShakingData {
        public float forceToCenter { get; set; }
        public float damping { get; set; }
        public float coef { get; set; }
        public float duration { get; set; }
    }
}