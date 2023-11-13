using System.Collections.Generic;
using UnityEngine;

namespace Snake.Body
{
    public class BodySnakeView : MonoBehaviour
    {
        public PartOfBodySnakeView PartOfBodySnakePrefab;
        public readonly List<PartOfBodySnakeView> PartsOfBodySnake = new();
    }
}