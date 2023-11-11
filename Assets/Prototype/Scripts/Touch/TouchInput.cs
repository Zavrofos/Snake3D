using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace Prototype.Scripts.Touch
{
    public class TouchInput : MonoBehaviour
    {
        [SerializeField]
        private Vector2 JoystickSize = new Vector2(300, 300);
        [SerializeField]
        private FloatingJoystick Joystick;

        private Finger _movementFinger;
        public Vector2 Direction;
        public Vector2 PreviousPosition;

        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
            ETouch.Touch.onFingerDown += HandleFingerDown;
            ETouch.Touch.onFingerUp += HandleLoseFinger;
            ETouch.Touch.onFingerMove += HandleFingerMove;
        }

        private void OnDisable()
        {
            ETouch.Touch.onFingerDown -= HandleFingerDown;
            ETouch.Touch.onFingerUp -= HandleLoseFinger;
            ETouch.Touch.onFingerMove -= HandleFingerMove;
            EnhancedTouchSupport.Disable();
        }

        private void HandleFingerMove(Finger MovedFinger)
        {
            if (MovedFinger == _movementFinger)
            {
                Vector2 knobPosition;
                float maxMovement = JoystickSize.x / 2f;
                ETouch.Touch currentTouch = MovedFinger.currentTouch;

                if (Vector2.Distance(currentTouch.screenPosition, Joystick.RectTransform.anchoredPosition) > maxMovement)
                {
                    knobPosition = (currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition).normalized * maxMovement;
                }
                else
                {
                    knobPosition = currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition;
                }

                Joystick.Knob.anchoredPosition = knobPosition;

                if(knobPosition != Vector2.zero)
                {
                    Direction = knobPosition / maxMovement;
                }
            }
        }

        private void HandleLoseFinger(Finger LostFinger)
        {
            if (LostFinger == _movementFinger)
            {
                _movementFinger = null;
                Joystick.Knob.anchoredPosition = Vector2.zero;
                Joystick.gameObject.SetActive(false);
                //Direction = Vector2.zero;
            }
        }

        private void HandleFingerDown(Finger TouchedFinger)
        {
            if (_movementFinger == null)
            {
                _movementFinger = TouchedFinger;
                Direction = Vector2.zero;
                Joystick.gameObject.SetActive(true);
                Joystick.RectTransform.sizeDelta = JoystickSize;
                Joystick.RectTransform.anchoredPosition = ClampStartPosition(TouchedFinger.screenPosition);
            }
        }

        private Vector2 ClampStartPosition(Vector2 StartPosition)
        {
            if (StartPosition.x < JoystickSize.x / 2)
            {
                StartPosition.x = JoystickSize.x / 2;
            }

            if(StartPosition.x > Screen.width - JoystickSize.x / 2)
            {
                StartPosition.x = Screen.width - JoystickSize.x / 2;
            }

            if (StartPosition.y < JoystickSize.y / 2)
            {
                StartPosition.y = JoystickSize.y / 2;
            }
            else if (StartPosition.y > Screen.height - JoystickSize.y / 2)
            {
                StartPosition.y = Screen.height - JoystickSize.y / 2;
            }

            return StartPosition;
        }
    }
}
