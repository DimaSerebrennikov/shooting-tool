using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    /// 
    public partial interface IExtendedHealth {
        float damageToTick { get; set; }
        float normalTickDamage { get; }
        float decaySpeed { get; }
    }
}