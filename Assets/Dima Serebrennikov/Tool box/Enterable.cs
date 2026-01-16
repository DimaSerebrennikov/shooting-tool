// Enterable.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\Enterable.csEnterable.cs
using System;
using System.Collections.Generic;
using System.IO;
namespace Serebrennikov.Tb {
    public class Enterable {
        Action onEnter;
        Action onQuit;
        bool _isActive;
        public void WaitEnter(Action onEnter) => this.onEnter = onEnter;
        public void WaitQuit(Action onQuit) => this.onQuit = onQuit;
        public bool isActive => _isActive;
        public void Enter() {
            _isActive = true;
            onEnter?.Invoke();
        }
        public void Quit() {
            _isActive = false;
            onQuit?.Invoke();
        }
    }
}
