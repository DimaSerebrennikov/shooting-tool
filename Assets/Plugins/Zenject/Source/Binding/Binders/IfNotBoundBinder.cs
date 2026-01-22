using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Zenject {
    [NoReflectionBaking]
    public class IfNotBoundBinder {
        public IfNotBoundBinder(BindInfo bindInfo) {
            BindInfo = bindInfo;
        }

        // Do not use this
        public BindInfo BindInfo {
            get;
        }

        public void IfNotBound() {
            BindInfo.OnlyBindIfNotBound = true;
        }
    }
}
