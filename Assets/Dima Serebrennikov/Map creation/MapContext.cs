using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class MapContext : MonoBehaviour {
        public Action<Component> Created = _ => {};
    }
}