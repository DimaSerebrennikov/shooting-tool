// Signal.csC:\Feeble snow\Assets\Serebrennikov\Bullet tags\Signal.csSignal.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class Signal : MonoBehaviour {
        Action onSignal = () => {};
        public void Execute() {
            onSignal();
        }
        public void Set(Action registration) {
            onSignal = registration;
        }
    }
}
