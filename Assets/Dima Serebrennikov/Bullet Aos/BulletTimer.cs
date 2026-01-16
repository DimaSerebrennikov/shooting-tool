using System;
using UnityEngine;
namespace Serebrennikov {
    internal class BulletTimer {
        float _counter;
        float _limit;
        ITimerResult _timerResult;
        public BulletTimer(float limit, ITimerResult timerResult) {
            _limit = limit;
            _timerResult = timerResult;
        }
        public void Update(float dt) {
            _counter += dt;
            if (_counter > _limit) {
                _timerResult.TimeIsOut = true;
            }
        }
    }
}
