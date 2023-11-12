using UnityEngine;

namespace Snake.MoveController
{
    public class MovementController
    {
        public readonly float SpeedSnake;
        public Vector3 Position;

        public MovementController(float speedSnake)
        {
            SpeedSnake = speedSnake;
        }
    }
}