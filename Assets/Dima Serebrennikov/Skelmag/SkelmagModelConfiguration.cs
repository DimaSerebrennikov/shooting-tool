using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class SkelmagModelConfiguration : MonoBehaviour, ISkelmagModel {
        [SerializeField] float _attackSpeed;
        [SerializeField] float _speed;
        public float AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }
        public float Speed { get => _speed; set => _speed = value; }
    }
}