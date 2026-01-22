using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public abstract class FigureCommandBehaviour : MonoBehaviour {
        public abstract void Prepare(IFigure a);
    }
}
