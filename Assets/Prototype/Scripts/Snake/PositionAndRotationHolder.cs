using UnityEngine;

namespace Prototype.Scripts.Snake
{
    public class PositionAndRotationHolder
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public bool IsEatedFood = false;

        public PositionAndRotationHolder(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}