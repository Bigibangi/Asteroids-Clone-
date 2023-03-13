using GameLogic.Core.Components;
using Leopotam.Ecs;

namespace GameLogic.Core.Systems {

    public class DirectionSystem : IEcsInitSystem {
        private readonly EcsFilter<Direction> _directtionFilter = null;

        public void Init() {
            foreach (var i in _directtionFilter) {
                ref var directionComponent =ref _directtionFilter.Get1(i);
                ref var direction = ref directionComponent.direction;
                direction = UnityEngine.Vector2.up;
            }
        }
    }
}