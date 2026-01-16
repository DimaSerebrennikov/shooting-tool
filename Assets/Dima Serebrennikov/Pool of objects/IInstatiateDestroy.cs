using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    /// Callbacks for high level creation
    public interface IInstatiateDestroy<TPool> {
        IDisposable WaitInstantiate(Action<TPool> on);
        IDisposable WaitDispose(Action<TPool> on);
    }
}