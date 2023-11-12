using Assets.Scripts;
using UnityEngine;

namespace Snake
{
    public class MovementUpdater : IFixedUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public MovementUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void FixedUpdate()
        {
            var position = _gameView.MovementController.Rigb.position;
            var rayDirection = _gameView.SurfaceForMovement.position - position;
            
            var ray = new Ray(position, rayDirection);
            if (Physics.Raycast(ray, out var hit, rayDirection.magnitude, LayerMask.GetMask("SurfaceForMovement")))
            {
                var upDirection = -rayDirection.normalized;
                _gameView.MovementController.Rigb.MovePosition(hit.point + upDirection);
                _gameView.MovementController.Rigb.MoveRotation(Quaternion.FromToRotation(-_gameView.MovementController.transform.up, rayDirection) * _gameView.MovementController.transform.rotation);
            }
            
            var transform1 = _gameView.MovementController.transform;
            var forward = transform1.forward * _gameModel.TouchModel.LerpDirection.y;
            var right = transform1.right * _gameModel.TouchModel.LerpDirection.x;
            
            _gameView.MovementController.Rigb.velocity = (forward + right) * _gameModel.MovementController.SpeedSnake;

            _gameModel.MovementController.Position = position;
        }
    }
}