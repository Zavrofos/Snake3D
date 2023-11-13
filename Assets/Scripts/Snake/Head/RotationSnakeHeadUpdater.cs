using Assets.Scripts;
using Touch;
using UnityEngine;

namespace Snake.Head
{
    public class RotationSnakeHeadUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public RotationSnakeHeadUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            TouchModel touchModel = _gameModel.TouchModel;
            SnakeHeadView snakeHeadView = _gameView.SnakeHeadView;
            
            float angle = touchModel.LerpAngle * Mathf.Rad2Deg;
            snakeHeadView.Head.localRotation = Quaternion.Euler(new Vector3(0, angle,0));
        }
    }
}