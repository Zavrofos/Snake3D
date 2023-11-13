using Assets.Scripts;
using Snake.MoveController;
using UnityEngine;

namespace Snake.Head
{
    public class SnakeHeadMoveUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public SnakeHeadMoveUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            MovementController movementController = _gameModel.MovementController;
            MovementControllerView movementControllerView = _gameView.MovementController;
            Transform surfaceForMovement = _gameView.SurfaceForMovement;
            SnakeHeadView snakeHeadView = _gameView.SnakeHeadView;
            SnakeModel snakeModel = _gameModel.SnakeModel;
            
            var position = movementController.Position;
            var rayDirection = surfaceForMovement.position - position;
            var ray = new Ray(position, rayDirection);
            
            if (Physics.Raycast(ray, out var hit1, rayDirection.magnitude, LayerMask.GetMask("Apple")))
            {
                var upDirection = -rayDirection.normalized * 0.5f;
                snakeHeadView.transform.position = hit1.point + upDirection;
                snakeHeadView.transform.rotation = Quaternion.FromToRotation(-movementControllerView.transform.up, rayDirection) * snakeHeadView.transform.rotation;
                snakeModel.Head.Position = snakeHeadView.transform.position;
                snakeModel.Head.Rotation = snakeHeadView.Head.transform.rotation;
            }
        }
    }
}