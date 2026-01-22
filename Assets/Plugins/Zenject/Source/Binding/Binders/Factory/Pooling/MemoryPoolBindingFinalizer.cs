using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ModestTree;
using UnityEngine;
namespace Zenject {
    [NoReflectionBaking]
    public class MemoryPoolBindingFinalizer<TContract> : ProviderBindingFinalizer {
        readonly MemoryPoolBindInfo _poolBindInfo;
        readonly FactoryBindInfo _factoryBindInfo;

        public MemoryPoolBindingFinalizer(
            BindInfo bindInfo, FactoryBindInfo factoryBindInfo, MemoryPoolBindInfo poolBindInfo)
            : base(bindInfo) {
            // Note that it doesn't derive from MemoryPool<TContract>
            // when used with To<>, so we can only check IMemoryPoolBase
            Assert.That(factoryBindInfo.FactoryType.DerivesFrom<IMemoryPool>());
            _factoryBindInfo = factoryBindInfo;
            _poolBindInfo = poolBindInfo;
        }

        protected override void OnFinalizeBinding(DiContainer container) {
            FactoryProviderWrapper<TContract> factory = new(
                _factoryBindInfo.ProviderFunc(container), new InjectContext(container, typeof(TContract)));
            MemoryPoolSettings settings = new(
                _poolBindInfo.InitialSize, _poolBindInfo.MaxSize, _poolBindInfo.ExpandMethod);
            TransientProvider transientProvider = new(
                _factoryBindInfo.FactoryType,
                container,
                _factoryBindInfo.Arguments.Concat(
                    InjectUtil.CreateArgListExplicit(factory, settings)).ToList(),
                BindInfo.ContextInfo, BindInfo.ConcreteIdentifier, null);
            IProvider mainProvider;
            if (BindInfo.Scope == ScopeTypes.Unset || BindInfo.Scope == ScopeTypes.Singleton) {
                mainProvider = BindingUtil.CreateCachedProvider(transientProvider);
            } else {
                Assert.IsEqual(BindInfo.Scope, ScopeTypes.Transient);
                mainProvider = transientProvider;
            }
            RegisterProviderForAllContracts(container, mainProvider);
        }
    }
}
