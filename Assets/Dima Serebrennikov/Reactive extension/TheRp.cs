using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using R3;
namespace Serebrennikov {
    public static class TheRp {
        public static void Execute<T>(this Subject<T> e, T value) => e.OnNext(value);
        public static void Execute(this Subject<Unit> e) => e.OnNext(Unit.Default);
        public static IDisposable Sub<T>(this Observable<T> extension, Action on) => extension.Subscribe(e => on());
        public static IDisposable SubscribeEmpty<T>(this Observable<T> extension, Action on) => extension.Subscribe(e => on());
        public static IDisposable Sub<T>(this Observable<T> extension) => extension.Subscribe();
        public static IDisposable Sub<T>(this Observable<T> extension, Action<T> on) => extension.Subscribe(on);
    }
    public class RProperty<T> : ReactiveProperty<T> {
        public RProperty() {}
        public RProperty(T value) : base(value) {}
        public RProperty(T value, [CanBeNull] IEqualityComparer<T> equalityComparer) : base(value, equalityComparer) {}
        protected RProperty(T value, [CanBeNull] IEqualityComparer<T> equalityComparer, bool callOnValueChangeInBaseConstructor) : base(value, equalityComparer, callOnValueChangeInBaseConstructor) {}
    }
    public class Subject : Subject<Unit> {}
}
