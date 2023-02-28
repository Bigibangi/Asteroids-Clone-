using System;

namespace GameLogic.Components {

    [Serializable]
    public struct AccelerationComponent {
        public float acceleration;
        public float maxSpeed;
        public float accelerationDirection;
    }
}