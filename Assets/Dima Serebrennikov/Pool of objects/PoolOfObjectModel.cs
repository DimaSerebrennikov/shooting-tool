// PoolOfObjectModel.csC:\GameDev\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\PoolOfObjectModel.csPoolOfObjectModel.cs
using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using R3;
using UnityEngine;
namespace Serebrennikov {
    /// данный класс предоставляет запуленным объектам колбеки
    public class PoolOfObjectModel<TPool> : IDisposable, IPoolOfObject<TPool> where TPool : IReceiveInstatiateDestroy {
        PoolOfObject<TPool> _pool = new();
        CompositeDisposable d = new();
        [CanBeNull] Action onDestroyPool;
        PoolOfObjectModel() {}
        public static PoolOfObjectModel<TPool> New() {
            PoolOfObjectModel<TPool> model = new();
            model.ProvidePoolCallbackToItsChildren();
            return model;
        }
        public void Dispose() {
            onDestroyPool?.Invoke();
            _pool.Dispose();
            d.Dispose();
        }
        public IDisposable WaitInstantiate(Action<TPool> on) {
            return _pool.WaitInstantiate(on);
        }
        public IDisposable WaitDispose(Action<TPool> on) {
            return _pool.WaitDispose(on);
        }
        public TPool InstatiateFromPool() {
            return _pool.InstatiateFromPool();
        }
        public void InstatiateFromPoolAsVoid() {
            InstatiateFromPool();
        }
        public void DestroyToPool(TPool dead) {
            _pool.DestroyToPool(dead);
        }
        public void SetPoolObject(Func<TPool> onGet) {
            _pool.SetPoolObject(onGet);
        }
        void ProvidePoolCallbackToItsChildren() {
            _pool.WaitCreation(WhenPooledObjectCreated).AddTo(d);
            _pool.WaitInstantiate(p => p.InstantiateFromPool()).AddTo(d);
            _pool.WaitDispose(p => p.DestroyToPool()).AddTo(d);
        }
        void WhenPooledObjectCreated(TPool p) {
            onDestroyPool += p.RetireFromPool;
            new Disposer(() => onDestroyPool += p.RetireFromPool).AddTo(d);
        }
    }
}
