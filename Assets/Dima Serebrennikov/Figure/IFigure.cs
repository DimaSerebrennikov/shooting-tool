// IFigure.csC:\v12\Feeble snow\Assets\Serebrennikov\Feeble snow\IFigure.csIFigure.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public interface IFigure : IReceiveInstatiateDestroy {
        void WaitInstantiate(Action on);
        void WaitDestroy(Action on);
        Transform FigureTransform { get; set; }
        IPoolOfObject<IFigure> ParentPool { get; set; }
        Subject OnCollisionWithWarm { get; set; } /*Вызывается при касании с тёплым телом, конфигурация оповещает.*/
        List<IFigure> FigureList_All { get; set; } /*Список всех фигур, которые сейчас активны.*/
        Subject OnReveal { get; set; } /*Вызывается от метода обнаружения соседних фигур.*/
        float DistanceToReveal { get; set; }
        public void Remove();
        public IDisposable WaitRemove(Action onRemove);
        public IDisposable WaitCollision(Action<GameObject> onCollision);
    }
}
