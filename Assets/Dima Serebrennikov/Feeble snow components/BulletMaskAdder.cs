// BulletMaskAdder.csC:\Feeble snow\Assets\Serebrennikov\Feeble snow components\BulletMaskAdder.csBulletMaskAdder.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class BulletMaskAdder : MonoBehaviour {
        [SerializeField] BulletMask _mask;
        void Awake() {
            _mask = TheUnityObject.InstanceFromAsset(_mask);
            _mask.Mask.Add(gameObject);
        }
    }
}
