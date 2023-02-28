using GameLogic.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Systems {

    public sealed class RotationSystem : IEcsRunSystem {
        private readonly EcsFilter<RotationComponent, DirectionComponent, ModelComponent> _rotationFilter = null;

        public void Run() {
            foreach (var i in _rotationFilter) {
                ref var rotationComponent = ref _rotationFilter.Get1(i);
                ref var directionComponent = ref _rotationFilter.Get2(i);
                ref var modelComponent = ref _rotationFilter.Get3(i);
                ref var rotationSpeed = ref rotationComponent.rotationSpeed;
                ref var direction = ref directionComponent.direction;
                ref var transform = ref modelComponent.modelTransform;
                ref var rotationAxis = ref rotationComponent.rotationAxis;
                //Bug
                transform.Rotate(transform.forward, -rotationAxis * rotationSpeed * Time.deltaTime);
                direction = transform.up;
            }
        }
    }
}