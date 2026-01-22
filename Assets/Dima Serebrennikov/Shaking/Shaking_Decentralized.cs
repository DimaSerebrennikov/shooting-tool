using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class Shaking_Decentralized {
        IShakingContext _a;
        public Shaking_Decentralized(IShakingContext a) {
            _a = a;
        }
        public void Start() {
            _a.Center = _a.ObjectToManipulate.localPosition;
        }
        public void Update(float dt) {
            _a.Timer += dt;
            for (int i = 0; i < _a.Dots.Count; i++) {
                float localTimer = _a.Timer - _a.Dots[i].FromTime;
                float timeNorm = localTimer / _a.Dots[i].Duration;
                if (timeNorm > 1f) {
                    _a.Dots.RemoveAt(i);
                } else {
                    float elapsedForce = _a.Dots[i].Curve(timeNorm) * _a.Dots[i].Force;
                    _a.Velocity += _a.Dots[i].Direction * elapsedForce;
                }
            }
            Vector3 directionToCenter = _a.Center - _a.ObjectToManipulate.localPosition;
            float distance = Vector3.Distance(_a.Center, _a.ObjectToManipulate.localPosition);
            directionToCenter.Normalize();
            _a.Velocity += directionToCenter * (_a.ForceToCenter * distance);
            _a.ObjectToManipulate.localPosition += _a.Velocity * 0.01f;
            _a.Velocity *= _a.Damping;
        }
        public void Shake(List<GravityDot> dots, float time, float coef) {
            Vector3 randomVector3 = new Vector3(TheRng.Norm(), TheRng.Norm(), TheRng.Norm()).normalized;
            GravityDot dot = new(randomVector3, Curve, time, 0.1f, coef);
            dots.Add(dot);
        }
        public void Shake2D(List<GravityDot> dots, float time, float coef, DirectionStyle noAxis) {
            Vector3 randomVector3 = noAxis switch {
                DirectionStyle.X => new Vector3(0f, TheRng.Norm(), TheRng.Norm()).normalized,
                DirectionStyle.Y => new Vector3(TheRng.Norm(), 0f, TheRng.Norm()).normalized,
                _ => new Vector3(TheRng.Norm(), TheRng.Norm(), 0f).normalized
            };
            GravityDot dot = new(randomVector3, Curve, time, 0.1f, coef);
            dots.Add(dot);
        }
        public float Curve(float x) {
            if (x > 1) {
                x = 1f;
            }
            float result = Mathf.Pow(1 - x, 2.2f);
            return result;
        }
    }
}
