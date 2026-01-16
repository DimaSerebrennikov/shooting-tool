using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    /// Any damage dealing
    public interface IHealth {
        void Deal(float value);
    }
}