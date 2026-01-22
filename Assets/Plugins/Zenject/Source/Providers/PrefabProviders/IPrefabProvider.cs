using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;
#if !NOT_UNITY3D

namespace Zenject {
    public interface IPrefabProvider {
        Object GetPrefab(InjectContext context);
    }
}

#endif
