using UnityEngine;

namespace FoodDir
{
    public class SpawnFoodPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;
        private int _countId;
        private readonly Collider[] _results;

        public SpawnFoodPresenter(GameModel gameModel, GameView gameView, int maxFoodCollisionResultCount)
        {
            _gameModel = gameModel;
            _gameView = gameView;
            _results = new Collider[maxFoodCollisionResultCount];
        }
        
        public void Subscribe()
        {
            _gameModel.SpawnFoodModel.SpawnedFood += OnSpawnFood;
        }

        public void Unsubscribe()
        {
            _gameModel.SpawnFoodModel.SpawnedFood -= OnSpawnFood;
        }

        private void OnSpawnFood()
        {
            SpawnFoodView spawnFoodView = _gameView.SpawnFoodView;
            SpawnFoodModel spawnFoodModel = _gameModel.SpawnFoodModel;
            
            Vector3 position;
            do
            {
                position = GetRandomPosition();
            } while (IsThereFoodNearby(position));
            
            FoodModel foodModel = new FoodModel(_countId);
            spawnFoodModel.ActiveFood.Add(_countId, foodModel);
            FoodView foodView = GameObject.Instantiate(spawnFoodView.FoodPrefab, position, Quaternion.identity, spawnFoodView.transform);
            foodView.Id = _countId;
            spawnFoodView.ActiveFoodView.Add(_countId, foodView);
            _countId++;
        }

        private bool IsThereFoodNearby(Vector3 position)
        {
            SpawnFoodModel spawnFoodModel = _gameModel.SpawnFoodModel;
            var size = Physics.OverlapSphereNonAlloc(position, spawnFoodModel.RadiusCheckNearFood, _results, LayerMask.GetMask("Food"));
            return size != 0;
        }

        private Vector3 GetRandomPosition()
        {
            SpawnFoodView spawnFoodView = _gameView.SpawnFoodView;
            SpawnFoodModel spawnFoodModel = _gameModel.SpawnFoodModel;
            
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);
            
            if (x == 0 && y == 0 && z == 0) x = 1;
            
            var direction = new Vector3(x, y, z).normalized;
            
            if (Physics.Raycast(spawnFoodView.transform.position + direction * 
                    spawnFoodModel.LengthRayForSpawnFood, -direction * 
                    spawnFoodModel.LengthRayForSpawnFood, 
                    out var hit, spawnFoodModel.LengthRayForSpawnFood, 
                    LayerMask.GetMask("Apple")))
            {
                return hit.point + direction;
            }
            
            return Vector3.zero;
        }
    }
}