// IValueMax.csC:\Feeble snow\Assets\Serebrennikov\Bullet tags\IValueMax.csIValueMax.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public interface IValueMax {
        float Value { get; set; }
        float Max { get; }
    }
}
