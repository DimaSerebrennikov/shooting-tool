using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Zenject {
    [NoReflectionBaking]
    public class SubContainerCreatorBindInfo {
        // Null = means no custom default parent
        public string DefaultParentName {
            get;
            set;
        }

        public bool CreateKernel {
            get;
            set;
        }

        public Type KernelType {
            get;
            set;
        }
    }
}
