using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    /// 
    public interface IExtendedHealth {
        float damageToTick { get; set; }
        float normalTickDamage { get; }
        float decaySpeed { get; }
    }
}
