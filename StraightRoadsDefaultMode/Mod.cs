using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;

namespace StraightRoadsDefaultMode {
    public class Mod : IMod {
        private static ILog log = LogManager.GetLogger($"{nameof(StraightRoadsDefaultMode)}.{nameof(Mod)}").SetShowsErrorsInUI(false);


        public void OnLoad(UpdateSystem updateSystem) {
            log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                log.Info($"Current mod asset at {asset.path}");
            updateSystem.UpdateAt<ReactToEvents>(SystemUpdatePhase.ToolUpdate);
        }



        public void OnDispose() {
            log.Info(nameof(OnDispose));
        }
    }
}