// EnterableEvt.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\EnterableEvt.csEnterableEvt.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public class EnterableEvt {
        Action<PointerUpEvent> onEnter;
        Action onQuit;
        bool _isActive;
        public void WaitEnter(Action<PointerUpEvent> onEnter) => this.onEnter = onEnter;
        public void WaitQuit(Action onQuit) => this.onQuit = onQuit;
        public bool isActive => _isActive;
        public void Enter(PointerUpEvent evt) {
            _isActive = true;
            onEnter?.Invoke(evt);
        }
        public void Quit() {
            _isActive = false;
            onQuit?.Invoke();
        }
    }
}
