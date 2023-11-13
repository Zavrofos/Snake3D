using System.Collections.Generic;
using UnityEngine;

namespace FoodDir
{
    public class MoveFoodToHeadSnakeUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public MoveFoodToHeadSnakeUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            List<FoodModel> removedFood = new();

            foreach (var foodModel in _gameModel.SpawnFoodModel.ActiveFood.Values)
            {
                if (foodModel.CurrentStateFood != StateFood.MoveToHeadSnake) continue;
                
                FoodView food = _gameView.SpawnFoodView.ActiveFoodView[foodModel.Id];
                var direction = (_gameModel.SnakeModel.Head.Position - food.transform.position).normalized;
                food.transform.Translate(direction * _gameModel.SpawnFoodModel.SpeedFood * Time.deltaTime);
                
                if (Vector3.Distance(food.transform.position, _gameModel.SnakeModel.Head.Position) < 0.5)
                {
                    removedFood.Add(foodModel);
                }
            }

            foreach (var foodModel in removedFood)
            {
                _gameModel.SpawnFoodModel.RemoveFood(foodModel);
            }
        }
    }
}