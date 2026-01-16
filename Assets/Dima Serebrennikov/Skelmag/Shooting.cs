// Shooting.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\Cmd\Map\Shooting.csShooting.cs
using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class Shooting : ITick {
        readonly IAttackSpeed _attackSpeed;
        readonly Action _onShoot;
        const float _targetTime = 1f;
        float _attackTimer;
        public Shooting(Action onShoot) {
            _attackSpeed = new AttackSpeedModel();
            this._onShoot = onShoot;
        }
        public Shooting(Action onShoot, IAttackSpeed attackSpeed) {
            _attackSpeed = attackSpeed;
            this._onShoot = onShoot;
        }
        public void Tick() {
            _attackTimer -= _attackSpeed.AttackSpeed * Time.deltaTime;
        }
        public void Shoot() {
            if (Time.timeScale <= 0f) return;
            if (_attackTimer <= 0f) {
                _attackTimer = _targetTime;
                _onShoot();
            }
        }
    }
}
