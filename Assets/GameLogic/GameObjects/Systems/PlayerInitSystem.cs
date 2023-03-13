using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.GameObjects.Systems {

    public class PlayerInitSystem : IEcsInitSystem {
        private readonly PlayerShipData _playerShipData;

        public void Init() {
            Object.Instantiate(_playerShipData.PlayerPrefab);
        }
    }
}