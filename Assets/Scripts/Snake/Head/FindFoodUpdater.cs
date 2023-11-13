using FoodDir;
using UnityEngine;

namespace Snake.Head
{
    public class FindFoodUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;
        private readonly Collider[] _results;

        public FindFoodUpdater(GameModel gameModel, GameView gameView, int maxFoodCollisionResultCount)
        {
            _gameModel = gameModel;
            _gameView = gameView;
            _results = new Collider[maxFoodCollisionResultCount];
        }
        
        public void Update()
        {
            SnakeModel snakeModel = _gameModel.SnakeModel;
            SpawnFoodModel spawnFoodModel = _gameModel.SpawnFoodModel;
            
            var size = Physics.OverlapSphereNonAlloc(snakeModel.Head.Position, 
                snakeModel.Head.RadiusFindFood, 
                _results, 
                LayerMask.GetMask("Food"));
            
            for (int i = 0; i < size; i++)
            {
                if (_results[i].TryGetComponent(out FoodView foodView) && spawnFoodModel.ActiveFood.TryGetValue(foodView.Id, out var foodModel))
                {
                    foodModel.CurrentStateFood = StateFood.MoveToHeadSnake;
                }
            }
        }
    }
}