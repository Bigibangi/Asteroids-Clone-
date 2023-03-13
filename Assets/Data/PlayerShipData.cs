using UnityEngine;

[CreateAssetMenu]
public class PlayerShipData : ScriptableObject {
    [SerializeField, Range (0,10)] private float _speed;
    [SerializeField, Range (0,10)] private float _maxSpeed;
    [SerializeField, Range (0,3)] private float _acceleration;
    [SerializeField] private GameObject _playerPrefab;

    public float Speed => _speed;
    public float MaxSpeed => _maxSpeed;
    public float Acceleration => _acceleration;
    public GameObject PlayerPrefab => _playerPrefab;
}