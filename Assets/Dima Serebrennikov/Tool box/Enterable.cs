// Enterable.csC:\GameDev\Halette\Assets\SereDim\Script\Editor\UnityEditor\EditorWindow\Enterable.csEnterable.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov.Tb {
    public class Enterable {
        Action onEnter;
        Action onQuit;
        public void WaitEnter(Action onEnter) {
            this.onEnter = onEnter;
        }
        public void WaitQuit(Action onQuit) {
            this.onQuit = onQuit;
        }
        public bool isActive { get; private set; }
        public void Enter() {
            isActive = true;
            onEnter?.Invoke();
        }
        public void Quit() {
            isActive = false;
            onQuit?.Invoke();
        }
    }
}
