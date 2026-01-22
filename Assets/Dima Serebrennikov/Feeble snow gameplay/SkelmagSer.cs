// SkelmagSo.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\SkelmagSo.csSkelmagSo.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    [Serializable]
    public class SkelmagSer {
        [SerializeField] Camera _camera;
        [SerializeField] Transform _target;
        [SerializeField] ExtendedHealthSer _extendedHealth;
        public Camera camera { get => _camera; set => _camera = value; }
        public Transform target { get => _target; set => _target = value; }
        public ExtendedHealthSer extendedHealth { get => _extendedHealth; set => _extendedHealth = value; }
    }
}
