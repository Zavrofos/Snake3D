using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace Touch
{
    public class TouchInputPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameView _gameView;
        private Finger _movementFinger;

        public TouchInputPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Subscribe()
        {
            EnhancedTouchSupport.Enable();
            ETouch.Touch.onFingerDown += HandleFingerDown;
            ETouch.Touch.onFingerUp += HandleLoseFinger;
            ETouch.Touch.onFingerMove += HandleFingerMove;
        }

        public void Unsubscribe()
        {
            ETouch.Touch.onFingerDown -= HandleFingerDown;
            ETouch.Touch.onFingerUp -= HandleLoseFinger;
            ETouch.Touch.onFingerMove -= HandleFingerMove;
            EnhancedTouchSupport.Disable();
        }

        private void HandleFingerMove(Finger movedFinger)
        {
            TouchModel touchModel = _gameModel.TouchModel;
            FloatingJoystickView joystickView = _gameView.JoystickView;
            
            if (movedFinger == _movementFinger)
            {
                Vector2 knobPosition;
                float maxMovement = touchModel.JoystickSize.x / 2f;
                ETouch.Touch currentTouch = movedFinger.currentTouch;

                if (Vector2.Distance(currentTouch.screenPosition, joystickView.RectTransform.anchoredPosition) > maxMovement)
                {
                    knobPosition = (currentTouch.screenPosition - joystickView.RectTransform.anchoredPosition).normalized * maxMovement;
                }
                else
                {
                    knobPosition = currentTouch.screenPosition - joystickView.RectTransform.anchoredPosition;
                }

                joystickView.Knob.anchoredPosition = knobPosition;

                if(knobPosition != Vector2.zero)
                {
                    touchModel.TouchDirection = knobPosition / maxMovement;
                }
            }
        }

        private void HandleLoseFinger(Finger lostFinger)
        {
            FloatingJoystickView joystickView = _gameView.JoystickView;
            
            if (lostFinger == _movementFinger)
            {
                _movementFinger = null;
                joystickView.Knob.anchoredPosition = Vector2.zero;
                joystickView.gameObject.SetActive(false);
            }
        }

        private void HandleFingerDown(Finger touchedFinger)
        {
            TouchModel touchModel = _gameModel.TouchModel;
            FloatingJoystickView joystickView = _gameView.JoystickView;
            
            if (_movementFinger == null)
            {
                _movementFinger = touchedFinger;
                touchModel.TouchDirection = Vector2.zero;
                joystickView.gameObject.SetActive(true);
                joystickView.RectTransform.sizeDelta = touchModel.JoystickSize;
                joystickView.RectTransform.anchoredPosition = ClampStartPosition(touchedFinger.screenPosition);
            }
        }

        private Vector2 ClampStartPosition(Vector2 startPosition)
        {
            TouchModel touchModel = _gameModel.TouchModel;
            
            if (startPosition.x < touchModel.JoystickSize.x / 2)
            {
                startPosition.x = touchModel.JoystickSize.x / 2;
            }

            if(startPosition.x > Screen.width - touchModel.JoystickSize.x / 2)
            {
                startPosition.x = Screen.width - touchModel.JoystickSize.x / 2;
            }

            if (startPosition.y < touchModel.JoystickSize.y / 2)
            {
                startPosition.y = touchModel.JoystickSize.y / 2;
            }
            else if (startPosition.y > Screen.height - touchModel.JoystickSize.y / 2)
            {
                startPosition.y = Screen.height - touchModel.JoystickSize.y / 2;
            }

            return startPosition;
        }
    }
}
