using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    class BarrelHandler {
        Transform _barrel;
        IMovePosition a;
        public BarrelHandler(Transform barrel, IMovePosition a) {
            _barrel = barrel;
            this.a = a;
        }
        public void Start() {
            a.Position = _barrel.position;
            a.Direction = _barrel.forward;
        }
    }
}
