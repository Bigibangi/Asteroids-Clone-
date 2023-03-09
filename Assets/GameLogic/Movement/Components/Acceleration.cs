using System;

namespace GameLogic.Movement.Components {

    [Serializable]
    public struct Acceleration {
        public float acceleration;
        public float maxSpeed;
        public float accelerationDirection;
    }
}