using GameLogic.Core.Components;
using GameLogic.GameObjects.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Movement.Systems {

    public class RandomDirectionSystem : IEcsInitSystem {
        private readonly EcsFilter<EnemyTag, Direction> _randomDirectionFilter = null;

        public void Init() {
            foreach (var i in _randomDirectionFilter) {
                ref var directionComponent = ref _randomDirectionFilter.Get2(i);
                ref var direction = ref directionComponent.direction;
                var randomDirection = new Vector2(Random.rotation.x, Random.rotation.y);
                direction = randomDirection;
            }
        }
    }
}