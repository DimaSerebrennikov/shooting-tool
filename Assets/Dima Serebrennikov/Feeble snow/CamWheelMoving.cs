// CameraWheelMover.csC:\GameDev\Halette\Assets\SereDim\Script\Game\Cmd\Input\CameraWheelMover.csCameraWheelMover.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    /// It adjusts the Y position of a target Transform smoothly based on mouse wheel input, with clamped range and optional inverted scroll
    public class CamWheelMoving {
        Camera camera;
        Transform transform;
        float heightVelocity;
        float targetHeightOrSize;
        ICameraWheelData data;
        public CamWheelMoving(Camera camera, ICameraWheelData data) {
            this.camera = camera;
            this.data = data;
            transform = camera.transform;
            if (camera.orthographic) {
                targetHeightOrSize = camera.orthographicSize;
            } else {
                targetHeightOrSize = transform.position.y;
            }
        }
        float minHeight { get => data.minHeight; set => data.minHeight = value; }
        float maxHeight { get => data.maxHeight; set => data.maxHeight = value; }
        float smoothTime { get => data.smoothTime; set => data.smoothTime = value; }
        bool invert { get => data.invert; set => data.invert = value; }
        float scrollSensitivity { get => data.scrollSensitivity; set => data.scrollSensitivity = value; }
        public void Update() {
            if (Time.timeScale <= 0f) return;
            float scroll = Input.mouseScrollDelta.y;
            if (Mathf.Abs(scroll) > Mathf.Epsilon) {
                if (invert) scroll = -scroll;
                targetHeightOrSize = Mathf.Clamp(targetHeightOrSize + scroll * scrollSensitivity, minHeight, maxHeight);
            }
            if (camera.orthographic) {
                camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, targetHeightOrSize, ref heightVelocity, smoothTime);
            }
        }
    }
}
