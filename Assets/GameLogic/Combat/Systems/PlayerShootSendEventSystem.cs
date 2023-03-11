using GameLogic.Combat.Components;
using GameLogic.GameObjects.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Combat.Systems {

    public class PlayerShootSendEventSystem : IEcsRunSystem {
        private readonly EcsFilter<PlayerTag, WeaponTag> _playerWeaponFilter = null;

        public void Run() {
            if (!Input.GetKeyDown(KeyCode.Q)) return;
            foreach (var i in _playerWeaponFilter) {
                ref var entity = ref _playerWeaponFilter.GetEntity(i);
                entity.Get<ShootEvent>();
            }
        }
    }
}