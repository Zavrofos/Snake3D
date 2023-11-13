using System;
using System.Collections.Generic;

namespace FoodDir
{
    public class SpawnFoodModel
    {
        public readonly int InitialCountFood;
        public readonly float RadiusCheckNearFood = 5;
        public readonly int LengthRayForSpawnFood = 50;
        public readonly float SpeedFood;
        public Dictionary<int, FoodModel> ActiveFood = new();

        public event Action SpawnedFood;
        public event Action<FoodModel> RemovedFood;

        public SpawnFoodModel(int initialCountFood, float speedFood)
        {
            InitialCountFood = initialCountFood;
            SpeedFood = speedFood;
        }

        public void SpawnFood()
        {
            SpawnedFood?.Invoke();
        }

        public void RemoveFood(FoodModel food)
        {
            RemovedFood?.Invoke(food);
        }
    }
}