using GameLogic.Core.Components;
using GameLogic.Movement.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Movement.Systems {

    public sealed class MovementSystem : IEcsRunSystem {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<Model, Direction, Movable> _movableFilter = null;

        public void Run() {
            foreach (var i in _movableFilter) {
                ref var modelComponent = ref _movableFilter.Get1(i);
                ref var directionComponent = ref _movableFilter.Get2(i);
                ref var movableComponent = ref _movableFilter.Get3(i);

                ref var direction = ref directionComponent.direction;
                ref var transform = ref modelComponent.modelTransform;
                ref var speed = ref movableComponent.speed;
                transform.position += new Vector3(
                    direction.x,
                    direction.y)
                    * speed
                    * Time.deltaTime;
            }
        }
    }
}