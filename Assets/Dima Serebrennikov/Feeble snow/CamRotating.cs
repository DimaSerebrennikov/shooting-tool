// CameraRotating.csC:\GameDev\Halette\Assets\SereDim\Script\Game\Cmd\Input\CameraRotating.csCameraRotating.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    /// Rotates the camera using the E and R keys relative to the Y axis
    public class CamRotating {
        Camera _camera;
        ICameraWheelData _data;
        public CamRotating(Camera camera, ICameraWheelData data) {
            _camera = camera;
            _data = data;
        }
        float speed => _data.rotatingSpeed;
        public void Update() {
            if (Input.GetKey(KeyCode.E)) _camera.transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
            if (Input.GetKey(KeyCode.R)) _camera.transform.Rotate(Vector3.up, -speed * Time.deltaTime, Space.World);
        }
    }
}
