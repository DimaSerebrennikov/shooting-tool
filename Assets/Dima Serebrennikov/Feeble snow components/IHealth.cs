using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    /// Any damage dealing
    public interface IHealth {
        void Deal(float value);
    }
}
