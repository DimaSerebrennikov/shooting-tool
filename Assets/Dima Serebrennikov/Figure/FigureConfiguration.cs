using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
namespace Serebrennikov {
    public class FigureConfiguration : MonoBehaviour {
        [SerializeField] FigureCommandBehaviour _commandMb;
        [SerializeField] float _distanceToReveal;
        public Subject<GameObject> OnCollision { get; set; } = new();
        public float DistanceToReveal { get => _distanceToReveal; set => _distanceToReveal = value; }
        void OnTriggerEnter(Collider other) {
            OnCollision.Execute(other.gameObject);
        }
        public FigureCommandBehaviour CommandMb { get => _commandMb; set => _commandMb = value; }
        void OnCollisionEnter(Collision other) {
            OnCollision.Execute(other.gameObject);
        }
    }
}
