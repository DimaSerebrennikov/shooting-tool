using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
namespace Zenject {
    [DebuggerStepThrough]
    [NoReflectionBaking]
    public class ZenjectException : Exception {
        public ZenjectException(string message)
            : base(message) {}

        public ZenjectException(
            string message, Exception innerException)
            : base(message, innerException) {}
    }
}
