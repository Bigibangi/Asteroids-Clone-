using System;
using UnityEngine;

namespace GameLogic.Components {

    [Serializable]
    public struct MovableComponent {
        public CharacterController characterController;
        public float speed;
    }
}