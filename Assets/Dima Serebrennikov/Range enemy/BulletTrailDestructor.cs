// BulletTrailDestructor.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Range enemy\BulletTrailDestructor.csBulletTrailDestructor.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class BulletTrailDestructor : MonoBehaviour {
        [SerializeField] TrailRenderer trail;
        [SerializeField] float destroyDelay;
        bool isDestroying;
        void Awake() {
            if (trail == null) {
                trail = GetComponentInChildren<TrailRenderer>();
            }
        }
        public void DestroyBullet() {
            if (isDestroying) {
                return;
            }
            isDestroying = true;
            StartCoroutine(DestroyRoutine());
        }
        IEnumerator DestroyRoutine() {
            if (trail != null) {
                trail.emitting = false;
                yield return new WaitForSeconds(trail.time);
            }
            if (destroyDelay > 0f) {
                yield return new WaitForSeconds(destroyDelay);
            }
            Destroy(gameObject);
        }
    }
}
