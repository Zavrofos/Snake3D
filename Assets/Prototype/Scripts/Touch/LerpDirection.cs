using System;
using UnityEngine;

namespace Prototype.Scripts.Touch
{
    public class LerpDirection : MonoBehaviour
    {
        public TouchInput Touch;
        public Vector2 Direction;
        
        [SerializeField] private float SpeedLerpDirection;

        private float _toAngle;
        public float Angle;
        
        private void Update()
        {
            var touchDirection = Touch.Direction;
            
            float fromDegreeAngle = Angle * Mathf.Rad2Deg;

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

            float deltaAngle = Math.Abs(fromDegreeAngle - toDegreesAngle);
            if (deltaAngle > 180)
            {
                if (toDegreesAngle > fromDegreeAngle)
                    toDegreesAngle -= 360;
                else if (toDegreesAngle < fromDegreeAngle)
                    toDegreesAngle += 360;
            }

            Angle = fromDegreeAngle * Mathf.Deg2Rad;
            _toAngle = toDegreesAngle * Mathf.Deg2Rad;
            
            Angle = Mathf.Lerp(Angle, _toAngle, Time.deltaTime * SpeedLerpDirection);
            Direction = new Vector2(Mathf.Sin(Angle), Mathf.Cos(Angle));
        }
    }
}