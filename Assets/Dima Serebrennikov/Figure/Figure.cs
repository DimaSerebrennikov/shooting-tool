using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class Figure : IFigure {
        public Figure(IPoolOfObject<IFigure> a1, FigureConfiguration configurationInstance) {
            _configurationInstance = configurationInstance;
            configurationInstance.CommandMb = TheUnityObject.InstanceFromAsset(configurationInstance.CommandMb);
            ParentPool = a1;
            FigureTransform = _configurationInstance.transform;
            configurationInstance.CommandMb.Prepare(this);
        }
        FigureConfiguration _configurationInstance;
        Action _onInstantiate;
        Action _onDestroy;
        public Transform FigureTransform { get; set; }
        public IPoolOfObject<IFigure> ParentPool { get; set; }
        public Subject OnCollisionWithWarm { get; set; } = new();
        public List<IFigure> FigureList_All { get; set; }
        public Subject OnReveal { get; set; } = new();
        public float DistanceToReveal { get => _configurationInstance.DistanceToReveal; set => _configurationInstance.DistanceToReveal = value; }
        Action _onRemove = () => {};
        public void Remove() {
            _onRemove();
        }
        public IDisposable WaitRemove(Action onRemove) {
            _onRemove += onRemove;
            return new Disposer(() => {
                _onRemove -= onRemove;
            });
        }
        public IDisposable WaitCollision(Action<GameObject> onCollision) {
            return _configurationInstance.OnCollision.Sub(onCollision);
        }
        /*---*/
        public void InstantiateFromPool() {
            _onInstantiate?.Invoke();
        }
        public void DestroyToPool() {
            _onDestroy?.Invoke();
        }
        public void RetireFromPool() {} /*Пока-что пул никогда не удаляется*/
        public void WaitInstantiate(Action on) {
            _onInstantiate += on;
        }
        public void WaitDestroy(Action on) {
            _onDestroy += on;
        }
    }
}