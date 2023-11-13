using UnityEngine;

namespace Camera
{
    public class CameraMoveUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;

        public CameraMoveUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            var surfacePosition = _gameView.SurfaceForMovement.position;
            var direction = (_gameModel.MovementController.Position - surfacePosition).normalized;
            _gameView.CameraView.position = surfacePosition + direction * _gameModel.CameraModel.DistanceCamera;
            _gameView.CameraView.rotation = Quaternion.LookRotation(-direction, _gameView.CameraView.transform.up);
        }
    }
}