using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using GameLogic.Systems;

public sealed class EcsStartUp : MonoBehaviour {
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
            .Add(new MovementSystem());
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