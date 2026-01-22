// AccuracyView.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Range enemy\AccuracyView.csAccuracyView.cs
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
namespace Serebrennikov {
    class AccuracyView : MonoBehaviour {
        [SerializeField] TextMeshPro _tmp;
        [SerializeField] HitSignal _hitSignal;
        [SerializeField] Transform _boundPt;
        [SerializeField] Transform _centerPt;
        float _maxDistance;
        Action<Vector3> _onHit;
        void Awake() {
            CacheDistance();
            _hitSignal = TheUnityObject.InstanceFromAsset(_hitSignal);
            _hitSignal.Signal += a => {
                UpdateValue(a.position);
            };
        }
        void CacheDistance() {
            _maxDistance = Vector3.Distance(_boundPt.position, _centerPt.position);
        }
        void UpdateValue(Vector3 a) {
            float distance = Vector3.Distance(a, _centerPt.position);
            float value = distance / _maxDistance;
            float converted = 1f - (float)Math.Round(value, 2);
            int percent = (int)(converted * 100f);
            _tmp.text = percent + " %";
        }
    }
}
