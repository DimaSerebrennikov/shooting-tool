using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public interface IMapToIFigure {
        List<IFigure> existingFigures { get; set; }
    }
}