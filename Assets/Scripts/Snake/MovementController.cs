using UnityEngine;

namespace Snake
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