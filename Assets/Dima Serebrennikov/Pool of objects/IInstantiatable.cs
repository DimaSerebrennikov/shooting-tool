using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    /// High level usage of pool of object
    public interface IInstantiatable<TPool> : IInstatiateDestroy<TPool> {
        public TPool InstatiateFromPool();     /*Создать объект из пула*/
        public void DestroyToPool(TPool dead); /*Удалить объект в пул*/
    }
}