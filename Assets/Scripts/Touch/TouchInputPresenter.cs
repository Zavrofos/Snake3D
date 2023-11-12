using Assets.Scripts;
using Prototype.Scripts.Touch;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace Touch
{
    public class TouchInputPresenter : IPresenter
    {
        private GameModel _gameModel;
        private GameView _gameView;
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

        private void HandleFingerMove(Finger MovedFinger)
        {
            if (MovedFinger == _movementFinger)
            {
                Vector2 knobPosition;
                float maxMovement = _gameModel.TouchModel.JoystickSize.x / 2f;
                ETouch.Touch currentTouch = MovedFinger.currentTouch;

                if (Vector2.Distance(currentTouch.screenPosition, _gameView.JoystickView.RectTransform.anchoredPosition) > maxMovement)
                {
                    knobPosition = (currentTouch.screenPosition - _gameView.JoystickView.RectTransform.anchoredPosition).normalized * maxMovement;
                }
                else
                {
                    knobPosition = currentTouch.screenPosition - _gameView.JoystickView.RectTransform.anchoredPosition;
                }

                _gameView.JoystickView.Knob.anchoredPosition = knobPosition;

                if(knobPosition != Vector2.zero)
                {
                    _gameModel.TouchModel.TouchDirection = knobPosition / maxMovement;
                }
            }
        }

        private void HandleLoseFinger(Finger LostFinger)
        {
            if (LostFinger == _movementFinger)
            {
                _movementFinger = null;
                _gameView.JoystickView.Knob.anchoredPosition = Vector2.zero;
                _gameView.JoystickView.gameObject.SetActive(false);
            }
        }

        private void HandleFingerDown(Finger TouchedFinger)
        {
            if (_movementFinger == null)
            {
                _movementFinger = TouchedFinger;
                _gameModel.TouchModel.TouchDirection = Vector2.zero;
                _gameView.JoystickView.gameObject.SetActive(true);
                _gameView.JoystickView.RectTransform.sizeDelta = _gameModel.TouchModel.JoystickSize;
                _gameView.JoystickView.RectTransform.anchoredPosition = ClampStartPosition(TouchedFinger.screenPosition);
            }
        }

        private Vector2 ClampStartPosition(Vector2 StartPosition)
        {
            if (StartPosition.x < _gameModel.TouchModel.JoystickSize.x / 2)
            {
                StartPosition.x = _gameModel.TouchModel.JoystickSize.x / 2;
            }

            if(StartPosition.x > Screen.width - _gameModel.TouchModel.JoystickSize.x / 2)
            {
                StartPosition.x = Screen.width - _gameModel.TouchModel.JoystickSize.x / 2;
            }

            if (StartPosition.y < _gameModel.TouchModel.JoystickSize.y / 2)
            {
                StartPosition.y = _gameModel.TouchModel.JoystickSize.y / 2;
            }
            else if (StartPosition.y > Screen.height - _gameModel.TouchModel.JoystickSize.y / 2)
            {
                StartPosition.y = Screen.height - _gameModel.TouchModel.JoystickSize.y / 2;
            }

            return StartPosition;
        }
    }
}
