using GameLogic.GameObjects.Tags;
using GameLogic.Movement.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Movement.Systems {

    public class AccelerationSystem : IEcsRunSystem {
        private readonly EcsFilter<Acceleration, Movable> _accelerationFilter = null;
        private readonly EcsFilter<Movable, PlayerTag> _playerAccelerationFilter = null;
        private readonly UI _ui;

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
                foreach (var j in _playerAccelerationFilter) {
                    ref var playerMoveComponent = ref _playerAccelerationFilter.Get1(j);
                    ref var playerSpeed = ref playerMoveComponent.speed;
                    _ui.GameScreen.SpeedLabel.text = playerSpeed.ToString();
                }
            }
        }
    }
}