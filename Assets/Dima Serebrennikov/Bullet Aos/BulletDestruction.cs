using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal class BulletDestruction {
        ITimerResult _timer;
        GameObject _gameObject;
        public BulletDestruction(ITimerResult timer, GameObject gameObject) {
            _timer = timer;
            this._gameObject = gameObject;
        }
        public void Update() {
            if (_timer.TimeIsOut) {}
        }
        public void Destroy() {
            UnityEngine.Object.Destroy(_gameObject);
        }
    }
}
