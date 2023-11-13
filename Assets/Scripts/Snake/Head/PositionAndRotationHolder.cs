using UnityEngine;

namespace Snake.Head
{
    public class PositionAndRotationHolder
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public bool IsEatedFood = false;

        public PositionAndRotationHolder(Vector3 position, Quaternion rotation, bool isEatedFood)
        {
            Position = position;
            Rotation = rotation;
            IsEatedFood = isEatedFood;
        }
    }
}