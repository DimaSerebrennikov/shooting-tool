// EnemyHealthContextAdder.csC:\Feeble snow\Assets\Serebrennikov\Range enemy\EnemyHealthContextAdder.csEnemyHealthContextAdder.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class EnemyHealthContextAdder : MonoBehaviour, IHealth {
        [SerializeField] EnemyHealthContext _enemyHealthContext;
        [SerializeField] LimitedValueContext _health;
        void Awake() {
            _enemyHealthContext = TheUnityObject.InstanceFromAsset(_enemyHealthContext);
        }
        void Start() {
            _enemyHealthContext.EnemyHealth.Add(gameObject, this);
        }
        public void Deal(float value) {
            _health.Value -= value;
        }
    }
}
