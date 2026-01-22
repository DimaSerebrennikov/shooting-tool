using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;
namespace Zenject {
    [NoReflectionBaking]
    public class FactorySubContainerBinder<TParam1, TParam2, TContract>
        : FactorySubContainerBinderWithParams<TContract> {
        public FactorySubContainerBinder(
            DiContainer bindContainer, BindInfo bindInfo, FactoryBindInfo factoryBindInfo, object subIdentifier)
            : base(bindContainer, bindInfo, factoryBindInfo, subIdentifier) {}

        public ScopeConcreteIdArgConditionCopyNonLazyBinder ByMethod(Action<DiContainer, TParam1, TParam2> installerMethod) {
            SubContainerCreatorBindInfo subcontainerBindInfo = new();
            ProviderFunc =
                container => new SubContainerDependencyProvider(
                    ContractType, SubIdentifier,
                    new SubContainerCreatorByMethod<TParam1, TParam2>(
                        container, subcontainerBindInfo, installerMethod), false);
            return new ScopeConcreteIdArgConditionCopyNonLazyBinder(BindInfo);
        }

#if !NOT_UNITY3D
        public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder ByNewGameObjectMethod(
            Action<DiContainer, TParam1, TParam2> installerMethod) {
            GameObjectCreationParameters gameObjectInfo = new();
            ProviderFunc =
                container => new SubContainerDependencyProvider(
                    ContractType, SubIdentifier,
                    new SubContainerCreatorByNewGameObjectMethod<TParam1, TParam2>(
                        container, gameObjectInfo, installerMethod), false);
            return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(BindInfo, gameObjectInfo);
        }

        public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder ByNewPrefabMethod(
            Func<InjectContext, Object> prefabGetter, Action<DiContainer, TParam1, TParam2> installerMethod) {
            GameObjectCreationParameters gameObjectInfo = new();
            ProviderFunc =
                container => new SubContainerDependencyProvider(
                    ContractType, SubIdentifier,
                    new SubContainerCreatorByNewPrefabMethod<TParam1, TParam2>(
                        container,
                        new PrefabProviderCustom(prefabGetter),
                        gameObjectInfo, installerMethod), false);
            return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(BindInfo, gameObjectInfo);
        }

        public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder ByNewPrefabMethod(
            Object prefab, Action<DiContainer, TParam1, TParam2> installerMethod) {
            BindingUtil.AssertIsValidPrefab(prefab);
            GameObjectCreationParameters gameObjectInfo = new();
            ProviderFunc =
                container => new SubContainerDependencyProvider(
                    ContractType, SubIdentifier,
                    new SubContainerCreatorByNewPrefabMethod<TParam1, TParam2>(
                        container,
                        new PrefabProvider(prefab),
                        gameObjectInfo, installerMethod), false);
            return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(BindInfo, gameObjectInfo);
        }

        public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder ByNewPrefabResourceMethod(
            string resourcePath, Action<DiContainer, TParam1, TParam2> installerMethod) {
            BindingUtil.AssertIsValidResourcePath(resourcePath);
            GameObjectCreationParameters gameObjectInfo = new();
            ProviderFunc =
                container => new SubContainerDependencyProvider(
                    ContractType, SubIdentifier,
                    new SubContainerCreatorByNewPrefabMethod<TParam1, TParam2>(
                        container,
                        new PrefabProviderResource(resourcePath),
                        gameObjectInfo, installerMethod), false);
            return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(BindInfo, gameObjectInfo);
        }
#endif
    }
}
