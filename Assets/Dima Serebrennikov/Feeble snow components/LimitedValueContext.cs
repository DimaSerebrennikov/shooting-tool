// LimitedValueContext.csC:\Feeble snow\Assets\Serebrennikov\Bullet tags\LimitedValueContext.csLimitedValueContext.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class LimitedValueContext : MonoBehaviour, IValueMax {
        float _value;
        [SerializeField] float _max;
        [SerializeField] float _min;
        public float Value {
            get => _value;
            set {
                if (value > Max) {
                    OnTop?.Invoke();
                    _value = Max;
                } else if (value < Min) {
                    OnBottom?.Invoke();
                    _value = Min;
                } else {
                    _value = value;
                }
                OnChange?.Invoke();
            }
        }
        public float Max { get => _max; set => _max = value; }
        public float Min { get => _min; set => _min = value; }
        public IDisposable WaitBottom(Action onBottom) {
            OnBottom += onBottom;
            return new Disposer(() => OnBottom -= onBottom);
        }
        public Action OnBottom { get; set; }
        public Action OnTop { get; set; }
        public Action OnChange { get; set; }
    }
}
