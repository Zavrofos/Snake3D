using UnityEngine;

namespace Snake.Body
{
    public class CreatePartOfBodyPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public CreatePartOfBodyPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Subscribe()
        {
            _gameModel.SnakeModel.Body.CreatedPartOfBody += OnCreatePartOfBodySnake;
        }

        public void Unsubscribe()
        {
            _gameModel.SnakeModel.Body.CreatedPartOfBody -= OnCreatePartOfBodySnake;
        }

        private void OnCreatePartOfBodySnake()
        {
            BodySnakeView bodySnakeView = _gameView.BodySnakeView;
            
            PartOfBodySnakeView partOfBodySnakeView =
                GameObject.Instantiate(bodySnakeView.PartOfBodySnakePrefab,
                    bodySnakeView.transform);
            
            bodySnakeView.PartsOfBodySnake.Add(partOfBodySnakeView);
        }
    }
}