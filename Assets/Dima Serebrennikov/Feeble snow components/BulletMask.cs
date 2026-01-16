// BulletMask.csC:\Feeble snow\Assets\Serebrennikov\Bullet Aos\BulletMask.csBulletMask.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class BulletMask : MonoBehaviour {
        [SerializeField] List<GameObject> _mask;
        public List<GameObject> Mask { get => _mask; set => _mask = value; }
    }
}
