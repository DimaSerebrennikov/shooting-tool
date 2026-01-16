using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    /// Complete pool of object instrument for usage
    public interface IPoolOfObject<TPool> : IInstantiatable<TPool> {
        void SetPoolObject(Func<TPool> onGet);
    }
}