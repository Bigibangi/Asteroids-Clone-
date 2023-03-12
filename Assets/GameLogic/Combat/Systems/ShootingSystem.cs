using GameLogic.Combat.Components;
using GameLogic.Spawning.Components;
using Leopotam.Ecs;
using UnityEngine;

public class ShootingSystem : IEcsRunSystem {
    private readonly EcsFilter<Weapon, ShootEvent, Spawn> _weaponFilter = null;

    public void Run() {
        foreach (var i in _weaponFilter) {
            ref var weaponComponent = ref _weaponFilter.Get1(i);
            ref var spawnComponent = ref _weaponFilter.Get3(i);
            ref var weaponData =ref  weaponComponent.weaponData;
            ref var spawnPos = ref spawnComponent.spawnPos;
            var bullet = Object.Instantiate(weaponData.Bullet);
            bullet.transform.localPosition = spawnPos.transform.position;
        }
    }
}