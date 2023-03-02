using GameLogic.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Systems {

    public sealed class ConstrainedAreaSystem : IEcsRunSystem {
        private readonly EcsFilter<ModelComponent, ConstrainedAreaComponent> _constrainedModelFilter = null;

        public void Run() {
            foreach (var i in _constrainedModelFilter) {
                ref var modelComponent = ref _constrainedModelFilter.Get1(i);
                ref var constrainedAreaComponent = ref _constrainedModelFilter.Get2(i);
                ref var modelTransform = ref modelComponent.modelTransform;
                ref var constrainedArea = ref constrainedAreaComponent.constrainedArea;
                var newPosition = modelTransform.localPosition;
                if (modelTransform.localPosition.y > constrainedArea.yMax) { newPosition = new Vector3(newPosition.x, constrainedArea.yMin); }
                else if (modelTransform.localPosition.y < constrainedArea.yMin) { newPosition = new Vector3(newPosition.x, constrainedArea.yMax); }
                else if (modelTransform.localPosition.x > constrainedArea.xMax) { newPosition = new Vector3(constrainedArea.xMin, newPosition.y); }
                else if (modelTransform.localPosition.x < constrainedArea.xMin) { newPosition = new Vector3(constrainedArea.xMax, newPosition.y); }
                modelTransform.localPosition = newPosition;
            }
        }
    }
}