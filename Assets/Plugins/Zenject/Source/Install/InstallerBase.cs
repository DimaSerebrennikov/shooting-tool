using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Zenject {
    public abstract class InstallerBase : IInstaller {
        [Inject]
        DiContainer _container;

        protected DiContainer Container => _container;

        public virtual bool IsEnabled => true;

        public abstract void InstallBindings();
    }
}
