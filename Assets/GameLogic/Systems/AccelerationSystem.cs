using GameLogic.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Systems {

    public class AccelerationSystem : IEcsRunSystem {
        private readonly EcsFilter<AccelerationComponent, MovableComponent> _accelerationFilter = null;

        public void Run() {
            foreach (var i in _accelerationFilter) {
                ref var accelerationComponent = ref _accelerationFilter.Get1(i);
                ref var movableComponent = ref _accelerationFilter.Get2(i);
                ref var speed = ref movableComponent.speed;
                ref var acceleration = ref accelerationComponent.acceleration;
                ref var accelerationDirection = ref accelerationComponent.accelerationDirection;
                ref var maxSpeed = ref accelerationComponent.maxSpeed;
                speed += acceleration * accelerationDirection * Time.deltaTime;
                if (speed > maxSpeed) {
                    speed = maxSpeed;
                }
                else if (speed < 0) {
                    speed = 0;
                }
            }
        }
    }
}