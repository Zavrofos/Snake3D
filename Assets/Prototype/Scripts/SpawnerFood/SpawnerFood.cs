using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Prototype.Scripts.SpawnerFood
{
    public class SpawnerFood : MonoBehaviour
    {
        private readonly int _initialCountFood = 30;
        private readonly float _radiusCheckNearFood = 5;
        private readonly int _lengthRay = 50;

        [SerializeField] private LayerMask _appleLayerMask;
        [SerializeField] private LayerMask _foodLayerMask;
        [SerializeField] private Food _foodPrefab;
        
        private void Start()
        {
            for (int i = 0; i < _initialCountFood; i++)
            {
                SpawnFood();
            }
        }

        public void SpawnFood()
        {
            Vector3 position;
            do
            {
                position = GetRandomPosition();
            } while (IsThereFoodNearby(position));
            Food food = Instantiate(_foodPrefab, position, Quaternion.identity, transform);
        }

        private bool IsThereFoodNearby(Vector3 position)
        {
            var foods = Physics.OverlapSphere(position, _radiusCheckNearFood, _foodLayerMask);
            return foods.Length != 0;
        }

        private Vector3 GetRandomPosition()
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);
            
            if (x == 0 && y == 0 && z == 0) x = 1;
            
            var direction = new Vector3(x, y, z).normalized;
            
            if (Physics.Raycast(transform.position + direction * _lengthRay, -direction * _lengthRay, out var hit,_lengthRay, _appleLayerMask))
            {
                return hit.point + direction;
            }
            
            return Vector3.zero;
        }
    }
}