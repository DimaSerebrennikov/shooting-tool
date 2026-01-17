using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class EnemyBulletSystem : MonoBehaviour {
        [SerializeField] EnemyBulletViewSystem _view;
        [SerializeField] EnemyBulletMoveSystem _move;
        [SerializeField] EnemyBulletCollideSystem _collide;
        [SerializeField] EnemyBulletTimerSystem _timer;
        void Update() {
            _view.View();
            _move.Move();
            _collide.Collide();
            _timer.Timer();
        }
    }
}
