using Assets.Scripts;
using FoodDir;
using UnityEngine;

namespace Snake.Head
{
    public class FindFoodUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public FindFoodUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            var food = Physics.OverlapSphere(_gameModel.SnakeModel.Head.Position, _gameModel.SnakeModel.Head.RadiusFindFood, LayerMask.GetMask("Food"));
            foreach (var part in food)
            {
                if (part.TryGetComponent<FoodView>(out FoodView foodView))
                {
                    if (_gameModel.SpawnFoodModel.ActiveFood.ContainsKey(foodView.Id))
                    {
                        _gameModel.SpawnFoodModel.ActiveFood[foodView.Id].CurrentStateFood = StateFood.MoveToHeadSnake;
                    }
                }
            }
        }
    }
}