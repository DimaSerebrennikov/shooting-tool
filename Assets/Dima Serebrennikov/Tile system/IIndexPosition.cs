using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public interface IIndexPosition {
        Vector2Int IndexPosition { get; set; }
    }
}