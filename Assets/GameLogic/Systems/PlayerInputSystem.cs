using GameLogic.Components;
using GameLogic.Tags;
using Leopotam.Ecs;
using System;
using UnityEngine;

namespace GameLogic.Systems {

    public class PlayerInputSystem : IEcsRunSystem {
        private readonly EcsFilter<PlayerTag, DirectionComponent, ModelComponent, RotationComponent, AccelerationComponent> _directionFilter = null;
        private float _rotationAxis;
        private float _accelerationDirection;

        public void Run() {
            foreach (var i in _directionFilter) {
                ref var playerTag = ref _directionFilter.Get1(i);
                ref var directionComponent = ref _directionFilter.Get2(i);
                ref var modelComponent = ref _directionFilter.Get3(i);
                ref var rotationComponent = ref _directionFilter.Get4(i);
                ref var accelerationComponent = ref _directionFilter.Get5(i);
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