using Assets.Scripts;

namespace Snake.Body
{
    public class InitializeBodySnakePresenter : IPresenter
    {
        private GameModel _gameModel;
        public GameView _GameView;

        public InitializeBodySnakePresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _GameView = gameView;
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
            for (int i = 0; i < _gameModel.SnakeModel.InitialCountPartOfBody; i++)
            {
                _gameModel.SnakeModel.Body.CreatePartOfBody();
            }
        }
    }
}