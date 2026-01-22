// EnterableEvt.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\EnterableEvt.csEnterableEvt.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public class EnterableEvt {
        Action<PointerUpEvent> onEnter;
        Action onQuit;
        public void WaitEnter(Action<PointerUpEvent> onEnter) {
            this.onEnter = onEnter;
        }
        public void WaitQuit(Action onQuit) {
            this.onQuit = onQuit;
        }
        public bool isActive { get; private set; }
        public void Enter(PointerUpEvent evt) {
            isActive = true;
            onEnter?.Invoke(evt);
        }
        public void Quit() {
            isActive = false;
            onQuit?.Invoke();
        }
    }
}
