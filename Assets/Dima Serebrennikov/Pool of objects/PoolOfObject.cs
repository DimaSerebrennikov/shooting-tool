#nullable enable
using System;
using System.Collections.Generic;
using Serebrennikov;
namespace Serebrennikov {
    public class PoolOfObject<TPool> : IPoolOfObject<TPool>, IDisposable {
        Func<TPool>? _getPoolObject;
        Action<TPool>? _onRelease;     /*only when from the pool*/
        Action<TPool>? _onInstantiate; /*on any object creation */
        Action<TPool>? _onDestroy;     /*when go to the pool*/
        Action<TPool>? _onCreated;     /*only when firstly created*/
        Queue<TPool> _deads = new();
        public IDisposable WaitCreation(Action<TPool> on) {
            _onCreated += on;
            return new Disposer(_On);
            void _On() => _onCreated -= on;
        }
        public IDisposable WaitRelease(Action<TPool> on) {
            _onRelease += on;
            return new Disposer(_On);
            void _On() => _onRelease -= on;
        }
        public IDisposable WaitInstantiate(Action<TPool> on) {
            _onInstantiate += on;
            return new Disposer(_On);
            void _On() => _onInstantiate -= on;
        }
        public IDisposable WaitDispose(Action<TPool> on) {
            _onDestroy += on;
            return new Disposer(_On);
            void _On() => _onDestroy -= on;
        }
        public TPool InstatiateFromPool() {
            TPool result;
            if (_deads.Count > 0) {
                result = _deads.Dequeue();
                _onRelease?.Invoke(result);
            } else {
                result = _getPoolObject();
                _onCreated?.Invoke(result);
            }
            _onInstantiate?.Invoke(result);
            return result;
        }
        public void DestroyToPool(TPool dead) {
            _deads.Enqueue(dead);
            _onDestroy?.Invoke(dead);
        }
        public void SetPoolObject(Func<TPool> onGet) {
            _getPoolObject += onGet;
        }
        public void Dispose() => _deads.Clear();
    }
}
