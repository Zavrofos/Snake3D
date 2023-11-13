using System.Collections.Generic;
using Snake.Head;
using UnityEngine;

namespace Snake.Body
{
    public class PartOfBodySnakeView : MonoBehaviour
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