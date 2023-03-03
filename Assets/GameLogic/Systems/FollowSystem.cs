using GameLogic.Components;
using GameLogic.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Systems {

    public class FollowSystem : IEcsRunSystem {
        private readonly EcsFilter<FollowComponent, DirectionComponent, ModelComponent, EnemyTag> _enemyFilter = null;
        private readonly EcsFilter<ModelComponent, PlayerTag> _playerFilter = null;

        public void Run() {
            foreach (var i in _playerFilter) {
                ref var modelComponent = ref _playerFilter.Get1(i);
                ref var modelTransform = ref modelComponent.modelTransform;
                foreach (var j in _enemyFilter) {
                    ref var followComponent = ref _enemyFilter.Get1(j);
                    ref var directionComponent = ref _enemyFilter.Get2(j);
                    ref var enemyModelComponent = ref _enemyFilter.Get3(j);
                    ref var target = ref followComponent.target;
                    ref var direction = ref directionComponent.direction;
                    ref var enemyModelTransform = ref enemyModelComponent.modelTransform;
                    target = modelTransform.localPosition - enemyModelTransform.localPosition;
                    direction = new Vector2(target.x, target.y);
                }
            }
        }
    }
}