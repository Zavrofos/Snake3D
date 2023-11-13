using Assets.Scripts;
using UnityEngine;

namespace Touch
{
    public class LerpDirectionUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private float _toAngle;

        public LerpDirectionUpdater(GameModel gameModel)
        {
            _gameModel = gameModel;
        }
        
        public void Update()
        {
            var touchDirection = _gameModel.TouchModel.TouchDirection;
            
            float fromDegreeAngle = _gameModel.TouchModel.LerpAngle * Mathf.Rad2Deg;

            switch (fromDegreeAngle)
            {
                case > 180:
                    fromDegreeAngle -= 360;
                    break;
                case < -180:
                    fromDegreeAngle += 360;
                    break;
            }

            if (touchDirection != Vector2.zero)
            {
                touchDirection = touchDirection.normalized;
                _toAngle = Mathf.Atan2(touchDirection.x, touchDirection.y);
            }

            float toDegreesAngle = _toAngle * Mathf.Rad2Deg;

            float deltaAngle = Mathf.Abs(fromDegreeAngle - toDegreesAngle);
            if (deltaAngle > 180)
            {
                if (toDegreesAngle > fromDegreeAngle)
                    toDegreesAngle -= 360;
                else if (toDegreesAngle < fromDegreeAngle)
                    toDegreesAngle += 360;
            }

            _gameModel.TouchModel.LerpAngle = fromDegreeAngle * Mathf.Deg2Rad;
            _toAngle = toDegreesAngle * Mathf.Deg2Rad;
            
            _gameModel.TouchModel.LerpAngle = Mathf.Lerp(_gameModel.TouchModel.LerpAngle, _toAngle, Time.deltaTime * _gameModel.TouchModel.SpeedLerpDirection);
            _gameModel.TouchModel.LerpDirection = new Vector2(Mathf.Sin(_gameModel.TouchModel.LerpAngle), Mathf.Cos(_gameModel.TouchModel.LerpAngle));
        }
    }
}