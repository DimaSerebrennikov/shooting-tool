using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    ///
    public interface ISkelmagShooting {
        Transform Hands { get; set; }
        Transform Target { get; set; }
    }
}