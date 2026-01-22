using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    interface ITimerResult {
        bool TimeIsOut { get; set; }
    }
}
