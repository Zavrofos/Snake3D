using System.Collections.Generic;
using Snake.Head;
using UnityEngine;

namespace Snake.Body
{
    public class PartOfBodySnakeView : MonoBehaviour
    {
        public readonly Queue<PositionAndRotationHolder> History = new();
        
        public PositionAndRotationHolder Move(int gap)
        {
            if (History.Count < gap)
                return null;

            PositionAndRotationHolder holder = History.Dequeue();
            var partOfBodyTransform = transform;
            partOfBodyTransform.position = holder.Position;
            partOfBodyTransform.rotation = holder.Rotation;
            return holder;
        }
    }
}