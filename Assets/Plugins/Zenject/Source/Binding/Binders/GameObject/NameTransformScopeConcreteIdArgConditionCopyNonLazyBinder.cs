using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
#if !NOT_UNITY3D

namespace Zenject {
    [NoReflectionBaking]
    public class NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder : TransformScopeConcreteIdArgConditionCopyNonLazyBinder {
        public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(
            BindInfo bindInfo,
            GameObjectCreationParameters gameObjectInfo)
            : base(bindInfo, gameObjectInfo) {}

        public TransformScopeConcreteIdArgConditionCopyNonLazyBinder WithGameObjectName(string gameObjectName) {
            GameObjectInfo.Name = gameObjectName;
            return this;
        }
    }
}

#endif
