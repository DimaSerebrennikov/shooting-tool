using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    /// 
    public interface ISkelmagData {
        ISkelmagMovement _movement { get; set; }
        ISkelmagShooting _shooting { get; set; }
    }
}