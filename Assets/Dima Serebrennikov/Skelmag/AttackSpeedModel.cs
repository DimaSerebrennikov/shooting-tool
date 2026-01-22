// AttackSpeedHardCoded.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\Cmd\Map\AttackSpeedHardCoded.csAttackSpeedHardCoded.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class AttackSpeedModel : IAttackSpeed {
        public AttackSpeedModel(float attackSpeed = 1f) {
            AttackSpeed = attackSpeed;
        }
        public float AttackSpeed { get; }
    }
}
