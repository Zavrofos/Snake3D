using Assets.Scripts;
using UnityEngine;

namespace FoodDir
{
    public class MoveFoodToHeadSnakeUpdater : IUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public MoveFoodToHeadSnakeUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            foreach (var foodModel in _gameModel.SpawnFoodModel.ActiveFood.Values)
            {
                if (foodModel.CurrentStateFood != StateFood.MoveToHeadSnake) return;
                FoodView food = _gameView.SpawnFoodView.ActiveFoodView[foodModel.Id];
                var direction = (_gameModel.SnakeModel.Head.Position - food.transform.position).normalized;
                food.transform.Translate(direction * _gameModel.SpawnFoodModel.SpeedFood * Time.deltaTime);
                
                if (Vector3.Distance(food.transform.position, _gameModel.SnakeModel.Head.Position) < 0.5)
                {
                    _gameModel.SpawnFoodModel.RemoveFood(foodModel);
                }
            }
        }
    }
}