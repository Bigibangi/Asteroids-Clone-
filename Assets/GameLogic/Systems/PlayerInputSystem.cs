using GameLogic.Components;
using GameLogic.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Systems {

    public class PlayerInputSystem : IEcsRunSystem {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;

        private float _moveX;
        private float _moveY;

        public void Run() {
            SetDirection();
            foreach (var i in _directionFilter) {
                ref var directionComponent = ref _directionFilter.Get2(i);
                ref var direction = ref directionComponent.direction;
                direction.x = _moveX;
                direction.y = _moveY;
            }
        }

        private void SetDirection() {
            _moveX = Input.GetAxis("Horizontal");
            _moveY = Input.GetAxis("Vertical");
        }
    }
}