// CameraMb.csC:\Feeble snow\Assets\Serebrennikov\Feeble snow gameplay\CameraMb.csCameraMb.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
class CameraCreationAdjustment : MonoBehaviour {
    [SerializeField] Vector3 _startOffset;
    [SerializeField] Quaternion _rotation;
    void Start() {
        transform.Translate(_startOffset);
        transform.rotation = _rotation;
    }
}
