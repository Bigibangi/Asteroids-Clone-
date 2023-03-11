using GameLogic.Combat.Components;
using GameLogic.Core.Components;
using GameLogic.GameObjects.Tags;
using GameLogic.Movement.Components;
using GameLogic.Spawning.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.GameObjects.Systems {

    public class PlayerInputSystem : IEcsRunSystem {
        private readonly EcsFilter<PlayerTag, Direction, Model, Rotation, Acceleration> _playerFilter = null;
        private float _rotationAxis;
        private float _accelerationDirection;

        public void Run() {
            foreach (var i in _playerFilter) {
                ref var playerTag = ref _playerFilter.Get1(i);
                ref var directionComponent = ref _playerFilter.Get2(i);
                ref var modelComponent = ref _playerFilter.Get3(i);
                ref var rotationComponent = ref _playerFilter.Get4(i);
                ref var accelerationComponent = ref _playerFilter.Get5(i);
                ref var direction = ref directionComponent.direction;
                ref var transform = ref modelComponent.modelTransform;
                ref var rotationAxis = ref rotationComponent.rotationAxis;
                ref var accelerationDirection = ref accelerationComponent.accelerationDirection;
                direction = transform.up;
                Rotate();
                rotationAxis = _rotationAxis;
                Accelerate();
                accelerationDirection = _accelerationDirection;
            }
        }

        private void Accelerate() {
            if (Input.GetKey(KeyCode.W)) {
                _accelerationDirection = 1f;
            }
            else {
                _accelerationDirection = -1f;
            }
        }

        private void Rotate() {
            _rotationAxis = Input.GetAxis("Horizontal");
        }
    }
}