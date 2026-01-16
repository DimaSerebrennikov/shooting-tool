using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public interface IFigureLocator {
        int howMuchEnemiesOnTile { get; }
        Subject<ITile> setTile { get; set; }
        Subject<IGhost> onAfterCreateGhost { get; set; }
        Subject<List<ITile>> onSetListOfFigures { get; set; }
        Subject<ITile> onLocateFiguresOnTile { get; set; }
        bool Figure(IGhost ghost, out IFigure figure);
        bool Ghost(out IGhost ghost);
    }
}
