using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class TestListSomething : MonoBehaviour {
        [SerializeField] ListBehaviour _instance;
        [SerializeField] List<int> _someListOfInt = new();
        void Update() {
            _instance.UpdateList(_someListOfInt);
        }
    }
}
