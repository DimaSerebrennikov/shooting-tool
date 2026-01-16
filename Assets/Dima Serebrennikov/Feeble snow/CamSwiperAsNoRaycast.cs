// CampSwiperAsNoRaycast.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\Cmd\Input\CampSwiperAsNoRaycast.csCampSwiperAsNoRaycast.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class CamSwiperAsNoRaycast {
        Camera camera;
        Vector3 downPosition;
        Transform transform;
        ICamSense _data;
        public CamSwiperAsNoRaycast(Camera camera, Transform transform, ICamSense data) {
            this.camera = camera;
            this.transform = transform;
            _data = data;
        }
        public void Update() {
            if (Time.timeScale > 0f) {
                if (Input.GetMouseButtonDown(1)) {
                    downPosition = Input.mousePosition;
                } else if (Input.GetMouseButton(1)) {
                    ClickHold(Input.mousePosition);
                }
            }
        }
        void ClickHold(Vector3 curPosition) {
            Vector3 pixelDelta = curPosition - downPosition;
            downPosition = curPosition;
            Vector3 move = camera.transform.right * (-pixelDelta.x / _data.x) + camera.transform.forward * (-pixelDelta.y / _data.y);
            move.y = 0f;
            transform.position += move;
        }
    }
}
