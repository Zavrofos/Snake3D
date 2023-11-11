using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Scripts.Snake
{
    public class PartOfBodySnake : MonoBehaviour
    {
        public List<PositionAndRotationHolder> PositionsAndRotations;
        public List<PositionAndRotationHolder> OldPositionsAndRotations;
        private int _currentPositionIndex;
        
        public void Move()
        {
            if (PositionsAndRotations == null || PositionsAndRotations.Count == 0) return;

            var transform1 = transform;
            transform1.position = PositionsAndRotations[_currentPositionIndex].Position;
            transform1.rotation = PositionsAndRotations[_currentPositionIndex].Rotation;
            _currentPositionIndex++;

            if (_currentPositionIndex != PositionsAndRotations.Count) return;
            OldPositionsAndRotations = new List<PositionAndRotationHolder>(PositionsAndRotations);
            _currentPositionIndex = 0;
        }
    }
}