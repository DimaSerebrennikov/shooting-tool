// MapContext.csC:\Feeble snow\Assets\Serebrennikov\Map creation\MapContext.csMapContext.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public interface IMapContext {
        GameObject tilePrefab { get; }
        Component figurePrefab { get; }
        Transform target { get; }
        FigureEditorConfiguration figureConfiguration { get; }
        GameObject enemyPrefab { get; }
    }
}
