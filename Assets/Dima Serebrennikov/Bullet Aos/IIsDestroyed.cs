using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal interface IIsDestroyed {
        public bool IsDestroyed { get; set; }
    }
}