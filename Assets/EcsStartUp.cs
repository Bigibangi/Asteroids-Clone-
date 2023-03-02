using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using GameLogic.Systems;
using UnityEngine.InputSystem;

public sealed class EcsStartUp : MonoBehaviour {
    [SerializeField] private InputAction _inputAction;

    private EcsWorld _world;
    private EcsSystems _systems;

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

    private void AddInjections() {
    }

    private void AddOneFrames() {
    }

    private void AddSystems() {
        _systems
            .Add(new PlayerInputSystem())
            .Add(new MovementSystem())
            .Add(new AccelerationSystem())
            .Add(new RotationSystem())
            .Add(new ConstrainedAreaSystem());
    }

    private void OnDestroy() {
        if (_systems != null) {
            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}