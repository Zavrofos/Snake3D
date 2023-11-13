using System;
using UnityEngine;

namespace Snake.Head
{
    public class SnakeHeadModel
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public bool IsEatedFood;
        public readonly float RadiusFindFood;

        public SnakeHeadModel(float radiusFindFood)
        {
            RadiusFindFood = radiusFindFood;
        }
    }
}