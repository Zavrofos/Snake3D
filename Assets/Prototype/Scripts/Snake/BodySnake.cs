using System.Collections.Generic;
using UnityEngine;


namespace Prototype.Scripts.Snake
{
    public class BodySnake : MonoBehaviour
    {
        public List<PartOfBodySnake> Body;
        public PartOfBodySnake PartOfBodySnakePrefab;
        public int Gap = 100;
        
        public void UpdateGame(PositionAndRotationHolder holder)
        {
            var nextHolder = holder;

            for (int i = 0; i < Body.Count; i++)
            {
                Body[i].History.Enqueue(nextHolder);
                nextHolder = Body[i].Move(Gap);
                if (nextHolder == null) return;
            }
        }

        public void SpawnPartOfBodySnake()
        {
            PartOfBodySnake partOfBodySnake = Instantiate(PartOfBodySnakePrefab, transform);
            Body.Add(partOfBodySnake);
        }
    }
}