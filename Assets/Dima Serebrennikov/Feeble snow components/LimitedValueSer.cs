// LimitedValueSer.csC:\Feeble snow\Assets\Serebrennikov\Rolling ball\LimitedValueSer.csLimitedValueSer.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    [Serializable]
    public class LimitedValueSer {
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
        /// 
        public IDisposable WaitBottom(Action onBottom) {
            this.OnBottom += onBottom;
            return new Disposer(() => this.OnBottom -= onBottom);
        }
        public Action OnBottom { get; set; }
        public Action OnTop { get; set; }
        public Action OnChange { get; set; }
    }
}
