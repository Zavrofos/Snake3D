using UnityEngine;

namespace Touch
{
    public class TouchModel
    {
        public readonly Vector2 JoystickSize;
        public readonly float SpeedLerpDirection;
        public Vector2 TouchDirection;
        public Vector2 LerpDirection;
        public float LerpAngle;

        public TouchModel(Vector2 joystickSize, float speedLerpDirection)
        {
            JoystickSize = joystickSize;
            SpeedLerpDirection = speedLerpDirection;
        }
    }
}