using Assets.Scripts;
using UnityEngine;

namespace FoodDir
{
    public class RemoveFoodPresenter : IPresenter
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public RemoveFoodPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Subscribe()
        {
            _gameModel.SpawnFoodModel.RemovedFood += OnRemoveFood;
        }

        public void Unsubscribe()
        {
            _gameModel.SpawnFoodModel.RemovedFood -= OnRemoveFood;
        }

        private void OnRemoveFood(FoodModel obj)
        {
            _gameModel.SnakeModel.Head.IsEatedFood = true;
            FoodView foodView = _gameView.SpawnFoodView.ActiveFoodView[obj.Id];
            _gameView.SpawnFoodView.ActiveFoodView.Remove(obj.Id);
            GameObject.Destroy(foodView.gameObject);
            _gameModel.SpawnFoodModel.ActiveFood.Remove(obj.Id);
            _gameModel.SpawnFoodModel.SpawnFood();
        }
    }
}