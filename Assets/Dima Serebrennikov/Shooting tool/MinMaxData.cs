using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    class MinMaxData {
        public MinMaxConfiguration Configuration;
        public GameObject Parent;
        public MinMaxData(MinMaxConfiguration configuration, GameObject parent) {
            Configuration = configuration;
            Parent = parent;
        }
    }
}
