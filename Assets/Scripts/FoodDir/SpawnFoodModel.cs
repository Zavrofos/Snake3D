using System;

namespace FoodDir
{
    public class SpawnFoodModel
    {
        public readonly int InitialCountFood;
        public readonly float RadiusCheckNearFood = 5;
        public readonly int LengthRayForSpawnFood = 50;

        public event Action SpawnedFood;

        public SpawnFoodModel(int initialCountFood)
        {
            InitialCountFood = initialCountFood;
        }

        public void SpawnFood()
        {
            SpawnedFood?.Invoke();
        }
    }
}