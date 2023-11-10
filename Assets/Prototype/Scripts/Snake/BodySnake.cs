using System.Collections.Generic;
using UnityEngine;


namespace Prototype.Scripts.Snake
{
    public class BodySnake : MonoBehaviour
    {
        public List<PartOfBodySnake> Body;
        public PartOfBodySnake PartOfBodyPrefab;

        public void UpdateGame(Vector3 previousSnakeHeadPosition)
        {
            for (var i = 0; i < Body.Count; i++)
            {
                var part = Body[i];
                var partTransform = part.transform;
                part.PreviousPosition = partTransform.position;
                if (i == 0)
                {
                    partTransform.position = previousSnakeHeadPosition;
                }
                else
                {
                    partTransform.position = Body[i - 1].PreviousPosition;
                }
            }
        }
    }
}