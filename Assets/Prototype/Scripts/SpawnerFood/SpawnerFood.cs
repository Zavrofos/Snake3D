using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Prototype.Scripts.SpawnerFood
{
    public class SpawnerFood : MonoBehaviour
    {
        [SerializeField] private int _initialCountFood;
        [SerializeField] private LayerMask _appleLayerMask;
        [SerializeField] private Food _foodPrefab;
        private List<Food> _foodActive;

        private void Start()
        {
            _foodActive = new List<Food>();

            for (int i = 0; i < _initialCountFood; i++)
            {
                SpawnFood();
            }
        }

        private void SpawnFood()
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);

            if (x == 0 && y == 0 && z == 0) x = 1;
            
            var direction = new Vector3(x, y, z).normalized;
            Debug.DrawRay(transform.position, direction * 30, Color.red);
            if (Physics.Raycast(transform.position + direction * 50, -direction * 50, out var hit,50, LayerMask.GetMask("Apple")))
            {
                var position = hit.point + direction;
                Food food = Instantiate(_foodPrefab, position, Quaternion.identity);
                food.transform.rotation = Quaternion.FromToRotation(food.transform.up, hit.normal) * food.transform.rotation;
                _foodActive.Add(food);
            }
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SpawnFood();
            }
        }
    }
}