using GameLogic;
using GameLogic.Combat.Components;
using GameLogic.Core.Components;
using Leopotam.Ecs;
using UnityEngine;

public class ShootingSystem : IEcsRunSystem {
    private readonly EcsFilter<Weapon, ShootEvent> _weaponFilter = null;

    public void Run() {
        foreach (var i in _weaponFilter) {
            ref var entity = ref _weaponFilter.GetEntity(i);
            ref var weaponComponent = ref _weaponFilter.Get1(i);
            ref var weaponData =ref  weaponComponent.weaponData;
            var bullet = Object.Instantiate(weaponData.Bullet);
            EntityReference entityReference;
            if (bullet.TryGetComponent(out entityReference)) {
                var bulletEntity = entityReference.Entity;
                ref var directionComponent = ref bulletEntity.Get<Direction>();
                ref var direction = ref directionComponent.direction;
                direction = Vector2.left;
            }
        }
    }
}