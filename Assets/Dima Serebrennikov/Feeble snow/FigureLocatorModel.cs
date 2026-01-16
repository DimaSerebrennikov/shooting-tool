// FigureLocatorModel.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\FigureLocatorModel.csFigureLocatorModel.cs
using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    /*Это прячет сериализацию от сервисов. В остальной анемик*/
    public class FigureLocatorModel : IFigureLocator {
        IMapSerialization _data;
        Func<IGhost> getGhost;
        Func<IGhost, IFigure> getFigure;
        public Subject<ITile> setTile { get; set; } = new();
        public Subject<IGhost> onAfterCreateGhost { get; set; } = new();
        public Subject<List<ITile>> onSetListOfFigures { get; set; } = new();
        public Subject<ITile> onLocateFiguresOnTile { get; set; } = new();
        public bool Figure(IGhost ghost, out IFigure figure) {
            figure = getFigure(ghost);
            if (figure == null) return false;
            return true;
        }
        public bool Ghost(out IGhost ghost) {
            ghost = getGhost();
            if (ghost == null) return false;
            return true;
        }
        public FigureLocatorModel(IMapSerialization data, Func<IGhost> getGhost, Func<IGhost, IFigure> getFigure) {
            _data = data;
            this.getGhost = getGhost;
            this.getFigure = getFigure;
        }
        public int howMuchEnemiesOnTile => _data.howMuchEnemiesOnTile;
    }
}
