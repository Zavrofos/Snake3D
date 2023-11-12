using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Scripts.Snake
{
    public class PartOfBodySnake : MonoBehaviour
    {
        public Queue<PositionAndRotationHolder> History = new();

        public PositionAndRotationHolder Move(int gap)
        {
            if (History.Count < gap)
                return null;

            PositionAndRotationHolder holder = History.Dequeue();
            transform.position = holder.Position;
            transform.rotation = holder.Rotation;
            return holder;
        }
    }
}