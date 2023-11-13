using UnityEngine;

namespace Snake.Head
{
    public class PositionAndRotationHolder
    {
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;
        public readonly bool IsEatedFood;

        public PositionAndRotationHolder(Vector3 position, Quaternion rotation, bool isEatedFood)
        {
            Position = position;
            Rotation = rotation;
            IsEatedFood = isEatedFood;
        }
    }
}