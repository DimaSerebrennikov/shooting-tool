using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Zenject {
    [NoReflectionBaking]
    public class ConcreteIdArgConditionCopyNonLazyBinder : ArgConditionCopyNonLazyBinder {
        public ConcreteIdArgConditionCopyNonLazyBinder(BindInfo bindInfo)
            : base(bindInfo) {}

        public ArgConditionCopyNonLazyBinder WithConcreteId(object id) {
            BindInfo.ConcreteIdentifier = id;
            return this;
        }
    }
}
