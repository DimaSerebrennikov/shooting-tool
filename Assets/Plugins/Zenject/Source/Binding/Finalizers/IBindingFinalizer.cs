using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Zenject {
    public interface IBindingFinalizer {
        BindingInheritanceMethods BindingInheritanceMethod {
            get;
        }

        void FinalizeBinding(DiContainer container);
    }
}
