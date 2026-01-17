using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public sealed class EnemyBulletTimerSystem : MonoBehaviour {
        [SerializeField] float _timeToRemove = 2f;
        [SerializeField] EnemyBulletState _state;
        public void Timer() {
            List<EnemyBulletCollision> expired = new();
            for (int i = 0; i < _state.Timers.Count; i++) {
                _state.Timers[i] += Time.deltaTime;
                if (_state.Timers[i] >= _timeToRemove) {
                    expired.Add(_state.Views[i]);
                }
            }
            for (int i = expired.Count - 1; i >= 0; i--) {
                int index = _state.Views.IndexOf(expired[i]);
                if (index == -1) {
                    continue;
                }
                Destroy(_state.Views[index].gameObject);
                _state.Views.RemoveAt(index);
                _state.Timers.RemoveAt(index);
            }
        }
    }
}