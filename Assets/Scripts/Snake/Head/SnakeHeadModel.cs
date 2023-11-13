using System;
using UnityEngine;

namespace Snake.Head
{
    public class SnakeHeadModel
    {
        public readonly float RadiusFindFood;
        public Vector3 Position;
        public Quaternion Rotation;
        public bool IsEatedFood;
        
        public SnakeHeadModel(float radiusFindFood)
        {
            RadiusFindFood = radiusFindFood;
        }
    }
}