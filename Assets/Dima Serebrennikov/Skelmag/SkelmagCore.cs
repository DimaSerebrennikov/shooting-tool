// Skelmag.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\Skelmag.csSkelmag.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class SkelmagCore {
        readonly MouseDownTrigger _mouseTrigger;
        readonly Mousing2D _targetToMouse;
        readonly SkelmagMovement _movement;
        Shooting _shooting;
        public SkelmagCore(ISkelmagMovement movementData, ISkelmagShooting shootingData, ISkelmagModel model, Component _bulletPrefab) {
            _targetToMouse = new(shootingData.Hands, movementData.camera, shootingData.Target);
            _shooting = new(() => UnityEngine.Object.Instantiate(_bulletPrefab), model);
            _movement = new(movementData.animator, movementData.bodyPt, movementData.camera.transform, model);
            _mouseTrigger = new(_shooting.Shoot);
        }
        public void Start() {
            _targetToMouse.Start();
            Loop.Tick(_shooting);
            Loop.Tick(_movement);
            Loop.Tick(_mouseTrigger);
        }
    }
}
