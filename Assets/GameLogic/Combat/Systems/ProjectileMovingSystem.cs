using GameLogic.Combat.Tags;
using GameLogic.Core.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Combat.Systems {

    public class ProjectileMovingSystem : IEcsRunSystem {
        private readonly EcsFilter<ProjectileTag, Direction> _projectileFilter = null;

        public void Run() {
            foreach (var i in _projectileFilter) {
                ref var directionComponent = ref _projectileFilter.Get2(i);
                ref var direction = ref directionComponent.direction;
                direction = Vector2.up;
            }
        }
    }
}