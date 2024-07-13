using System;
using Colossal.Logging;
using Game;
using Game.Prefabs;
using Game.SceneFlow;
using Game.Tools;
using Game.UI.InGame;
using Game.UI.Tooltip;
using Unity.Entities;
using Unity.Jobs;

namespace StraightRoadsDefaultMode {
    public partial class ReactToEvents : GameSystemBase {
        
        private NetToolSystem _netToolSystem;
        
        protected override void OnCreate() {
            base.OnCreate();
            _netToolSystem = World.GetExistingSystemManaged<NetToolSystem>();
            var toolSystem = World.GetExistingSystemManaged<ToolSystem>();
            toolSystem.EventPrefabChanged = (Action<PrefabBase>)Delegate.Combine( new Action<PrefabBase>(EventPrefabChanged),toolSystem.EventPrefabChanged);
            toolSystem.EventToolChanged = (Action<ToolBaseSystem>)Delegate.Combine( new Action<ToolBaseSystem>(EventToolChanged),toolSystem.EventToolChanged);
        }

        private void EventToolChanged(ToolBaseSystem obj) {
            if (obj.GetPrefab() is RoadPrefab) {
                _netToolSystem.mode = NetToolSystem.Mode.Straight;
            }
        }
        private void EventPrefabChanged(PrefabBase prefab) {
            if (prefab is RoadPrefab) {
                _netToolSystem.mode = NetToolSystem.Mode.Straight;
            }
        }
        protected override void OnUpdate() {

        }
    }

}