// TransformConfiguration.csC:\Feeble snow\Assets\Serebrennikov\Bullet tags\TransformConfiguration.csTransformConfiguration.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class TransformConfiguration : MonoBehaviour {
        Transform _barrel;
        public Transform Barrel {
            get {
                if (_barrel == null) {
                    _barrel = new GameObject().transform;
                }
                return _barrel;
            }
            set => _barrel = value;
        }
    }
}
