using GameLogic.Core.Components;
using GameLogic.GameObjects.Tags;
using GameLogic.Movement.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.GameObjects.Systems {

    public class PlayerInputSystem : IEcsRunSystem {
        private readonly EcsFilter<PlayerTag, Direction, Model, Rotation, Acceleration> _playerFilter = null;
        private UI _ui;
        private ShipInput _playerInput;

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
                rotationAxis = _playerInput.Player.Rotate.ReadValue<float>();
                accelerationDirection = _playerInput.Player.Accelerate.ReadValue<float>();
                _ui.GameScreen.PositionLabel.text = transform.localPosition.x.ToString() + " " + transform.localPosition.y.ToString();
                _ui.GameScreen.AngleLabel.text = Vector2.SignedAngle(direction, Vector2.up).ToString();
            }
        }
    }
}