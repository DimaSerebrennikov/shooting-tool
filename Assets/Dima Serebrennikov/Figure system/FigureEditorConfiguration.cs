using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class FigureEditorConfiguration : MonoBehaviour {
        public ListBehaviour SavedFigure;
        public ListBehaviour ActiveFigure;
        public ListBehaviour AddedActiveFigure;
        public ListBehaviour RemovedActiveFigure;
        public ListBehaviour FigureCollision;
        public ListBehaviour AddedView;
    }
}