using Assets.Scripts;

namespace Snake.Body
{
    public class InitializeBodySnakePresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public InitializeBodySnakePresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Subscribe()
        {
            _gameModel.Initialized += OnInitializeBodySnake;
        }

        public void Unsubscribe()
        {
            _gameModel.Initialized += OnInitializeBodySnake;
        }

        private void OnInitializeBodySnake()
        {
            SnakeModel snakeModel = _gameModel.SnakeModel;
            
            for (int i = 0; i < snakeModel.InitialCountPartOfBody; i++)
            {
                snakeModel.Body.CreatePartOfBody();
            }
        }
    }
}