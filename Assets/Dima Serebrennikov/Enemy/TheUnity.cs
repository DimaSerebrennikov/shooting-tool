using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public static class TheUnity {
        public static void Link(Transform source, Transform target, Vector3 offset) {
            PositionConstraint constraint = source.gameObject.AddComponent<PositionConstraint>();
            constraint.enabled = false;
            constraint.constraintActive = false;
            constraint.translationAxis = Axis.X | Axis.Y | Axis.Z;
            constraint.SetSources(new List<ConstraintSource>());
            ConstraintSource src = new() {
                sourceTransform = target,
                weight = 1f
            };
            constraint.AddSource(src);
            constraint.translationOffset = offset;
            constraint.locked = false;
            constraint.locked = true;
            constraint.constraintActive = true;
            constraint.enabled = true;
        }
    }
}