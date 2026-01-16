using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public interface IPeriodicShakingContext {
        float TargetTimeBetweenShakes { get; }
        float TimeBetweenShakes { get; set; }
        float CoefToShake { get; }
    }
}
