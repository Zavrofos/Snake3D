using Assets.Scripts;
using UnityEngine;

namespace Camera
{
    public class CameraMoveUpdater : IUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public CameraMoveUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update()
        {
            var direction = (_gameModel.MovementController.Position - _gameView.SurfaceForMovement.position).normalized;
            _gameView.CameraView.position = _gameView.SurfaceForMovement.position + direction * _gameModel.CameraModel.DistanceCamera;
            _gameView.CameraView.rotation = Quaternion.LookRotation(-direction, _gameView.CameraView.transform.up);
        }
    }
}