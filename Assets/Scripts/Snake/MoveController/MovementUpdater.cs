using Assets.Scripts;
using Touch;
using UnityEngine;

namespace Snake.MoveController
{
    public class MovementUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public MovementUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            MovementControllerView movementControllerView = _gameView.MovementController;
            MovementController movementController = _gameModel.MovementController;
            Transform surfaceForMovement = _gameView.SurfaceForMovement;
            TouchModel touchModel = _gameModel.TouchModel;
            
            var position = movementControllerView.Rigb.position;
            var rayDirection = surfaceForMovement.position - position;
            
            var ray = new Ray(position, rayDirection);
            if (Physics.Raycast(ray, out var hit, rayDirection.magnitude, LayerMask.GetMask("SurfaceForMovement")))
            {
                var upDirection = -rayDirection.normalized;
                movementControllerView.Rigb.MovePosition(hit.point + upDirection);
                movementControllerView.Rigb.MoveRotation(Quaternion.FromToRotation(-movementControllerView.transform.up, rayDirection) * movementControllerView.transform.rotation);
            }
            
            var movementControllerViewTransform = movementControllerView.transform;
            var forward = movementControllerViewTransform.forward * touchModel.LerpDirection.y;
            var right = movementControllerViewTransform.right * touchModel.LerpDirection.x;
            
            movementControllerView.Rigb.velocity = (forward + right) * movementController.SpeedSnake;

            movementController.Position = movementControllerViewTransform.position;
        }
    }
}