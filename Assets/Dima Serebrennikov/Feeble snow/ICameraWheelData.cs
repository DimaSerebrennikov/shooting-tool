// aToy.csC:\GameDev\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\aToy.csaToy.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public interface ICameraWheelData {
        float smoothTime { get; set; }
        float maxHeight { get; set; }
        float minHeight { get; set; }
        float scrollSensitivity { get; set; }
        bool invert { get; set; }
        float rotatingSpeed { get; set; }
    }
}
