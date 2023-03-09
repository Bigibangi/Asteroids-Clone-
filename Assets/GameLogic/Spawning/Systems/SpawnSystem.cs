using GameLogic.Spawning.Components;
using GameLogic.Core.Components;
using GameLogic.GameObjects.Tags;
using Leopotam.Ecs;

namespace GameLogic.Spawning.Systems {

    public sealed class SpawnSystem : IEcsInitSystem {
        private readonly EcsFilter<WeaponTag, Spawn, Direction, Model> _weaponFIlter = null;

        public void Init() {
            foreach (var i in _weaponFIlter) {
                ref var spawnComponent = ref _weaponFIlter.Get2(i);
                ref var directionComponent = ref _weaponFIlter.Get3(i);
                ref var modelComponent = ref _weaponFIlter.Get4(i);

                ref var spawnPos = ref spawnComponent.spawnPos;
                ref var direction = ref directionComponent.direction;
                ref var modelTransform = ref modelComponent.modelTransform;
                var position = spawnPos;
                modelTransform.localPosition = position.localPosition;
            }
        }
    }
}