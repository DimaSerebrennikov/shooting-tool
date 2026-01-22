// SkelmagMovementData.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\SkelmagMovementData.csSkelmagMovementData.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class SkelmagMovementData : ISkelmagMovement {
        public Animator animator { get; set; }
        public Transform bodyPt { get; set; }
        public Camera camera { get; set; }
        public SkelmagMovementData(SkelmagSer file, Transform bodyPt, Animator animator) {
            this.bodyPt = bodyPt;
            this.animator = animator;
            camera = TheUnityObject.InstanceFromAsset(file.camera);
        }
    }
}
