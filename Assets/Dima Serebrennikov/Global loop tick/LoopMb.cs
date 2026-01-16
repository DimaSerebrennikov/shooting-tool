using System;
using System.Collections.Generic;
using UnityEngine;
namespace Serebrennikov {
    public class LoopMb : MonoBehaviour {
        public ITicker model { get; set; }
        public IDisposable RegisterTick(ITick onTick) => model.RegisterTick(onTick);
        public IDisposable RegisterFixedTick(IFixedTick onTick) => model.RegisterFixedTick(onTick);
        public void Refresh() => model.Refresh();
        void Update() => model.Tick();
        void FixedUpdate() => model.FTick();
    }
}
