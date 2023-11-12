using Assets.Scripts;
using UnityEngine;

namespace Snake.Head
{
    public class RotationSnakeHeadUpdater : IUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public RotationSnakeHeadUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            float angle = _gameModel.TouchModel.LerpAngle * Mathf.Rad2Deg;
            _gameView.SnakeHeadView.Head.localRotation = Quaternion.Euler(new Vector3(0, angle,0));
        }
    }
}