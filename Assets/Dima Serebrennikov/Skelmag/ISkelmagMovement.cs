using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    /// 
    public interface ISkelmagMovement {
        Animator animator { get; set; }
        Transform bodyPt { get; set; }
        Camera camera { get; set; }
    }
}
