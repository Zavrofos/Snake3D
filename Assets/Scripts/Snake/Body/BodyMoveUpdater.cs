using Snake.Head;

namespace Snake.Body
{
    public class BodyMoveUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public BodyMoveUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            SnakeModel snakeModel = _gameModel.SnakeModel;

            PositionAndRotationHolder holder = new PositionAndRotationHolder(snakeModel.Head.Position,
                snakeModel.Head.Rotation, snakeModel.Head.IsEatedFood);
            PositionAndRotationHolder nextHolder = holder;

            snakeModel.Head.IsEatedFood = false;

            var body = _gameView.BodySnakeView.PartsOfBodySnake;
            
            for (int i = 0; i < body.Count; i++)
            {
                body[i].History.Enqueue(nextHolder);
                nextHolder = body[i].Move(snakeModel.Body.GapBetweenPositionsOfBodyParts);
                if (nextHolder == null) return;

                if (i == body.Count - 1)
                {
                    if (nextHolder.IsEatedFood)
                    {
                        snakeModel.Body.CreatePartOfBody();
                        break;
                    }
                }
            }
        }
    }
}