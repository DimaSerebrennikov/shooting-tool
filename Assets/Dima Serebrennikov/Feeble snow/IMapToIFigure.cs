using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public interface IMapToIFigure {
        List<IFigure> existingFigures { get; set; }
    }
}
