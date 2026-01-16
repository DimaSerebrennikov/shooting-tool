// Service.csC:\Feeble snow\Assets\Serebrennikov\Module manager\Service.csService.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal class Service {
        readonly Dictionary<Type, object> service = new();
        public TService Get<TService>()
            where TService : class, new() {
            Type serviceType = typeof(TService);
            if (service.TryGetValue(serviceType, out object instance)) {
                return (TService)instance;
            }
            instance = new TService();
            service.Add(serviceType, instance);
            return (TService)instance;
        }
        public void Reset<TService>()
            where TService : class {
            service.Remove(typeof(TService));
        }
        public void Clear() {
            service.Clear();
        }
    }
}
