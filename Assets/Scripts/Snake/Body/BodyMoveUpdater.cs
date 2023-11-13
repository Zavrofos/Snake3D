using Assets.Scripts;
using Snake.Head;

namespace Snake.Body
{
    public class BodyMoveUpdater : IUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public BodyMoveUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            PositionAndRotationHolder holder = new PositionAndRotationHolder(_gameModel.SnakeModel.Head.Position,
                _gameModel.SnakeModel.Head.Rotation, _gameModel.SnakeModel.Head.IsEatedFood);
            PositionAndRotationHolder nextHolder = holder;

            _gameModel.SnakeModel.Head.IsEatedFood = false;

            var body = _gameView.BodySnakeView.PartsOfBodySnake;
            
            for (int i = 0; i < body.Count; i++)
            {
                body[i].History.Enqueue(nextHolder);
                nextHolder = body[i].Move(_gameModel.SnakeModel.Body.GapBetweenPositionsOfBodyParts);
                if (nextHolder == null) return;

                if (i == body.Count - 1)
                {
                    if (nextHolder.IsEatedFood)
                    {
                        _gameModel.SnakeModel.Body.CreatePartOfBody();
                        break;
                    }
                }
            }
        }
    }
}