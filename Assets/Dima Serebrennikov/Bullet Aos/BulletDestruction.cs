using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;
namespace Serebrennikov {
    class BulletDestruction {
        ITimerResult _timer;
        GameObject _gameObject;
        public BulletDestruction(ITimerResult timer, GameObject gameObject) {
            _timer = timer;
            _gameObject = gameObject;
        }
        public void Update() {
            if (_timer.TimeIsOut) {}
        }
        public void Destroy() {
            Object.Destroy(_gameObject);
        }
    }
}
