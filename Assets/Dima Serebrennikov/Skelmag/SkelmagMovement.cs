// SkelmagMovement.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\SkelmagMovement.csSkelmagMovement.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class SkelmagMovement : ITick {
        readonly Translator _translator;
        readonly Transform _bodyPt;
        readonly AnimatorInput _input;
        readonly ISpeed _model;
        public SkelmagMovement(Animator animator, Transform bodyPt, Transform cameraPt, ISpeed model) {
            _bodyPt = bodyPt;
            _model = model;
            _translator = new Translator(cameraPt);
            _input = new AnimatorInput(animator);
        }
        public void Tick() {
            Vector2 input2 = TheInput.Get2Axes(); /*Get camera-relative input*/
            float mag = Mathf.Clamp01(input2.magnitude); /*Preserve raw input magnitude (for analog sticks)*/
            Vector2 world2 = _translator.Get(input2); /*Translate to world space (XZ plane)*/
            Vector3 world3 = new(world2.x, 0f, world2.y);
            Vector3 local3 = _bodyPt.InverseTransformDirection(world3); /*Convert to local space of body*/
            Vector2 local2 = new(local3.x, local3.z);
            local2 = TheMath.SquareNormalize(local2) * mag; /*Square-normalize so diagonals don’t run faster*/
            _input.Update(local2 * _model.Speed); /*Send to animator*/
        }
    }
}
