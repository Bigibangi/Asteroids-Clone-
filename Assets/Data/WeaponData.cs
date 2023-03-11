using UnityEngine;

namespace GameLogic.Combat.Components {

    [CreateAssetMenu]
    public class WeaponData : ScriptableObject {
        [SerializeField] private GameObject _projectilePrefab;

        public GameObject Bullet => _projectilePrefab;
    }
}