// SplashSystem.csC:\GameDev\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\SplashSystem.csSplashSystem.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class SplashSystemBehaviour : MonoBehaviour {
        [SerializeField] SplashMb _bulletSplashPrefab;
        public void Create(Vector3 position, Vector3 direction, Color color) {
            Quaternion rotation = Quaternion.LookRotation(direction);
            SplashMb curObj = Instantiate(_bulletSplashPrefab, position, rotation);
            curObj.splashParticleController.ChangeColor(color);
            curObj.splashParticleController.Play();
        }
    }
}
