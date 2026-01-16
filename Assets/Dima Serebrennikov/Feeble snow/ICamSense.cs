using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public interface ICamSense {
        float x { get; }
        float y { get; }
    }
}