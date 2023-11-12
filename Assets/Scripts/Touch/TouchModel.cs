using UnityEngine;

namespace Touch
{
    public class TouchModel
    {
        public readonly Vector2 JoystickSize;
        public Vector2 Direction;

        public TouchModel(Vector2 joystickSize)
        {
            JoystickSize = joystickSize;
        }
    }
}