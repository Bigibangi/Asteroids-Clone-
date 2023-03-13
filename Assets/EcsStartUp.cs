using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using GameLogic.Movement.Systems;
using GameLogic.GameObjects.Systems;
using GameLogic.Spawning.Systems;
using GameLogic.Combat.Components;
using GameLogic.Combat.Systems;
using GameLogic;
using GameLogic.Core.Systems;

public sealed class EcsStartUp : MonoBehaviour {
    [SerializeField] private UI _ui;
    [SerializeField] private PlayerShipData _playerShipData;

    private EcsWorld _world;
    private EcsSystems _systems;
    private ShipInput _shipInput;

    private void Awake() {
        _shipInput = new ShipInput();
    }

    #region MonoBehaviour

    private void Start() {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        _systems.ConvertScene();
        AddInjections();
        AddOneFrames();
        AddSystems();
        _systems.Init();
    }

    private void Update() {
        _systems?.Run();
    }

    private void OnEnable() {
        _shipInput.Enable();
    }

    private void OnDisable() {
        _shipInput.Disable();
    }

    private void OnDestroy() {
        if (_systems != null) {
            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }

    #endregion MonoBehaviour

    private void AddInjections() {
        _systems.
            Inject(_ui).
            Inject(_shipInput).
            Inject(_playerShipData);
    }

    private void AddOneFrames() {
        _systems
            .OneFrame<ShootEvent>();
    }

    private void AddSystems() {
        _systems
            .Add(new PlayerInitSystem())
            .Add(new PlayerInputSystem())
            .Add(new PlayerShootSendEventSystem())
            .Add(new EntityInitializeSystem())
            .Add(new DirectionSystem())
            .Add(new MovementSystem())
            .Add(new AccelerationSystem())
            .Add(new RotationSystem())
            .Add(new ConstrainedAreaSystem())
            .Add(new RandomDirectionSystem())
            .Add(new FollowSystem())
            .Add(new ShootingSystem())
            .Add(new SpawnSystem())
            .Add(new ProjectileMovingSystem());
    }
}