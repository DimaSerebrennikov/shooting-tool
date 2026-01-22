// FigureMb_New.csC:\Feeble snow\Assets\Serebrennikov\Feeble snow\FigureMb_New.csFigureMb_New.cs
using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEngine;
namespace Serebrennikov {
    public class FigureMb_New : MonoBehaviour {
        public Subject<GameObject> OnCollision { get; set; } = new();
        void OnTriggerEnter(Collider other) {
            OnCollision.Execute(other.gameObject);
        }
        void OnCollisionEnter(Collision other) {
            OnCollision.Execute(other.gameObject);
        }
    }
}
