// PlayerHealthContext.csC:\Feeble snow\Assets\Serebrennikov\Enemy\PlayerHealthContext.csPlayerHealthContext.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class PlayerHealthContext : MonoBehaviour {
        IHealth _playerHealth;
        public void Deal(float value) {
            _playerHealth?.Deal(value);
        }
        public void Set(IHealth playerHealth) {
            _playerHealth = playerHealth;
        }
    }
}
