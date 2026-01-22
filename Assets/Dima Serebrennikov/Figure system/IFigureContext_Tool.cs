// IFigureContext.csC:\Feeble snow\Assets\Serebrennikov\Figure system\IFigureContext.csIFigureContext.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public interface IFigureContext_Tool : IFigureContext {
        FigureEditorConfiguration HudConfiguration { get; }
    }
    public interface IFigureContext {
        Component FigurePrefab { get; }
        float TileSize { get; }
        Transform Target { get; }
        List<Tile> AddedTile { get; }
        List<Tile> RemovedTile { get; }
        List<Vector3> Revealed { get; }
    }
}
