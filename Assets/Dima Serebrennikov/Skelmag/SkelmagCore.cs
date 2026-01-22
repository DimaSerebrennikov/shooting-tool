// Skelmag.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\Skelmag.csSkelmag.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;
namespace Serebrennikov {
    public class SkelmagCore {
        readonly MouseDownTrigger _mouseTrigger;
        readonly Mousing2D _targetToMouse;
        readonly SkelmagMovement _movement;
        Shooting _shooting;
        public SkelmagCore(ISkelmagMovement movementData, ISkelmagShooting shootingData, ISkelmagModel model, Component _bulletPrefab) {
            _targetToMouse = new Mousing2D(shootingData.Hands, movementData.camera, shootingData.Target);
            _shooting = new Shooting(() => Object.Instantiate(_bulletPrefab), model);
            _movement = new SkelmagMovement(movementData.animator, movementData.bodyPt, movementData.camera.transform, model);
            _mouseTrigger = new MouseDownTrigger(_shooting.Shoot);
        }
        public void Start() {
            _targetToMouse.Start();
            Loop.Tick(_shooting);
            Loop.Tick(_movement);
            Loop.Tick(_mouseTrigger);
        }
    }
}
