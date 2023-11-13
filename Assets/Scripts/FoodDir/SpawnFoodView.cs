using System.Collections.Generic;
using UnityEngine;

namespace FoodDir
{
    public class SpawnFoodView : MonoBehaviour
    {
        public FoodView FoodPrefab;
        public readonly Dictionary<int, FoodView> ActiveFoodView = new();
    }
}