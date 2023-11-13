using Assets.Scripts;
using UnityEngine;

namespace Snake.Head
{
    public class SnakeHeadMoveUpdater : IUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public SnakeHeadMoveUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            var position = _gameModel.MovementController.Position;
            var rayDirection = _gameView.SurfaceForMovement.position - position;
            var ray = new Ray(position, rayDirection);
            
            if (Physics.Raycast(ray, out var hit1, rayDirection.magnitude, LayerMask.GetMask("Apple")))
            {
                var upDirection = -rayDirection.normalized * 0.5f;
                _gameView.SnakeHeadView.transform.position = hit1.point + upDirection;
                _gameView.SnakeHeadView.transform.rotation = Quaternion.FromToRotation(-_gameView.MovementController.transform.up, rayDirection) * _gameView.SnakeHeadView.transform.rotation;

                _gameModel.SnakeModel.Head.Position = _gameView.SnakeHeadView.transform.position;
                _gameModel.SnakeModel.Head.Rotation = _gameView.SnakeHeadView.Head.transform.rotation;
            }
        }
    }
}