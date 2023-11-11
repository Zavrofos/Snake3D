using System.Collections.Generic;
using UnityEngine;


namespace Prototype.Scripts.Snake
{
    public class BodySnake : MonoBehaviour
    {
        public List<PartOfBodySnake> Body;

        public void UpdateGameNew(List<PositionAndRotationHolder> oldHeadPositions)
        {
            for (var i = 0; i < Body.Count; i++)
            {
                var part = Body[i];
                if (i == 0)
                {
                    part.PositionsAndRotations = oldHeadPositions;
                    part.Move();
                }
                else
                {
                    part.PositionsAndRotations = Body[i - 1].OldPositionsAndRotations;
                    part.Move();
                }
            }
        }
    }
}