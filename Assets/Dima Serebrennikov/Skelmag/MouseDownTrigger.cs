// PcInputSkelmag.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\Cmd\Input\PcInputSkelmag.csPcInputSkelmag.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class MouseDownTrigger : ITick {
        readonly Action _on;
        public MouseDownTrigger(Action on) {
            _on = on;
        }
        public void Tick() {
            if (Input.GetMouseButton(0)) {
                _on?.Invoke();
            }
        }
    }
}
