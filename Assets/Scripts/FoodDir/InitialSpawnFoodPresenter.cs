using Assets.Scripts;

namespace FoodDir
{
    public class InitialSpawnFoodPresenter : IPresenter
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public InitialSpawnFoodPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Subscribe()
        {
            _gameModel.Initialized += OnSpawnFood;
        }

        public void Unsubscribe()
        {
            _gameModel.Initialized += OnSpawnFood;
        }

        private void OnSpawnFood()
        {
            for (int i = 0; i < _gameModel.SpawnFoodModel.InitialCountFood; i++)
            {
                _gameModel.SpawnFoodModel.SpawnFood();
            }
        }
    }
}