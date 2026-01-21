// DebugConfiguration.csC:\Users\DimaS\Desktop\FeebleSnowOriginal-master\Assets\Dima Serebrennikov\Shooting tool\DebugConfiguration.csDebugConfiguration.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    class DebugConfiguration : MonoBehaviour {
        [SerializeField] bool _saved = true;
        public bool Value { get; private set; }
        void Awake() {
            Debug.Log("start DebugConfiguration");
            Value = IntToBool(PlayerPrefs.GetInt(_key, BoolToInt(_saved)));
            Debug.Log("finish DebugConfiguration");
        }
        public void Set_Persistent(bool value) {
            Value = value;
            PlayerPrefs.SetInt(_key, BoolToInt(value));
            _saved = value;
        }
        public void Set_Temp(bool value) {
            Value = value;
        }
        static int BoolToInt(bool value) {
            return value ? 1 : 0;
        }
        static bool IntToBool(int value) {
            return value != 0;
        }
        const string _key = "RangeEnemy.Debug";
    }
}
