using Assets.Scripts;
using UnityEngine;

namespace FoodDir
{
    public class SpawnFoodPresenter : IPresenter
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public SpawnFoodPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
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
            Vector3 position;
            do
            {
                position = GetRandomPosition();
            } while (IsThereFoodNearby(position));
            FoodView food = GameObject.Instantiate(_gameView.SpawnFoodView.FoodPrefab, position, Quaternion.identity, _gameView.SpawnFoodView.transform);
        }

        private bool IsThereFoodNearby(Vector3 position)
        {
            var foods = Physics.OverlapSphere(position, _gameModel.SpawnFoodModel.RadiusCheckNearFood, LayerMask.GetMask("Food"));
            return foods.Length != 0;
        }

        private Vector3 GetRandomPosition()
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);
            
            if (x == 0 && y == 0 && z == 0) x = 1;
            
            var direction = new Vector3(x, y, z).normalized;
            
            if (Physics.Raycast(_gameView.SpawnFoodView.transform.position + direction * 
                    _gameModel.SpawnFoodModel.LengthRayForSpawnFood, -direction * 
                    _gameModel.SpawnFoodModel.LengthRayForSpawnFood, 
                    out var hit, _gameModel.SpawnFoodModel.LengthRayForSpawnFood, 
                    LayerMask.GetMask("Apple")))
            {
                return hit.point + direction;
            }
            
            return Vector3.zero;
        }
    }
}