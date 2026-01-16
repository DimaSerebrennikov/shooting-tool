using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal class MovingForward {
        IMovePosition a;
        public MovingForward(IMovePosition a) {
            this.a = a;
        }
        public void Update() {
            a.Position += a.Direction * (a.Speed * Time.fixedDeltaTime);
            a.Forward = a.Direction.normalized;
        }
    }
}