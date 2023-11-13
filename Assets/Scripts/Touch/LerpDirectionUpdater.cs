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
            TouchModel touchModel = _gameModel.TouchModel;
            
            var touchDirection = touchModel.TouchDirection;
            
            float fromDegreeAngle = touchModel.LerpAngle * Mathf.Rad2Deg;

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

            touchModel.LerpAngle = fromDegreeAngle * Mathf.Deg2Rad;
            _toAngle = toDegreesAngle * Mathf.Deg2Rad;
            
            touchModel.LerpAngle = Mathf.Lerp(touchModel.LerpAngle, _toAngle, Time.deltaTime * touchModel.SpeedLerpDirection);
            touchModel.LerpDirection = new Vector2(Mathf.Sin(touchModel.LerpAngle), Mathf.Cos(touchModel.LerpAngle));
        }
    }
}