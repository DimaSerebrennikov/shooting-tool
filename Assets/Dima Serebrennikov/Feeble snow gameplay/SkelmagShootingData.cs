// SkelmagShootingData.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\SkelmagShootingData.csSkelmagShootingData.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class SkelmagShootingData : ISkelmagShooting {
        public Transform Hands { get; set; }
        public Transform Target { get; set; }
        public SkelmagShootingData(SkelmagSer ser, Transform hands) {
            this.Hands = hands;
            Target = TheUnityObject.InstanceFromAsset(ser.target);
        }
    }
}
