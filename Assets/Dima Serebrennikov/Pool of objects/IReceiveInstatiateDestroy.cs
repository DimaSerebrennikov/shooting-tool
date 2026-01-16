// aPool.csC:\GameDev\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\aPool.csaPool.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public interface IReceiveInstatiateDestroy {
        void InstantiateFromPool();
        void DestroyToPool();
        void RetireFromPool();
    }
}
