// FactoryTicker.csC:\GameDev\Halette\Assets\SereDim\Script\Tool\FactoryTicker.csFactoryTicker.cs
using UnityEngine;
namespace Serebrennikov {
    public static class LoopBsl {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Run() {
            LoopMb _mono = new UnityEngine.GameObject("Loop").AddComponent<LoopMb>();
            var n = new Ticker();
            _mono.model = n;
            UnityEngine.Object.DontDestroyOnLoad(_mono);
            Loop instance = new(_mono);
        }
    }
}
