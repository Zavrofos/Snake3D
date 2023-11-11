using System.Collections.Generic;
using Prototype.Scripts.Snake;
using Prototype.Scripts.Touch;
using UnityEngine;

namespace Prototype.Scripts
{
    public class SnakeHeadMovement : MonoBehaviour
    {
        [SerializeField] private Transform _surfaceForMovement;
        [SerializeField] private LayerMask _appleLayerMask;
        [SerializeField] private LayerMask _surfaceLayerMask;
        [SerializeField] private float _speedMovement;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private LerpDirection LerpDirection;

        private float _vertical;
        private float _horizontal;

        public Transform MovingObjectOnAnApple;
        public BodySnake BodySnake;

        private List<PositionAndRotationHolder> _positionsAndRotations;
        private List<PositionAndRotationHolder> _previousPositionsAndRotations;

        public Transform Head;

        private void Start()
        {
            _positionsAndRotations = new List<PositionAndRotationHolder>();
            _previousPositionsAndRotations = new List<PositionAndRotationHolder>();
        }

        private void FixedUpdate()
        {
            var position = _rigidbody.position;
            var rayDirection = _surfaceForMovement.position - position;

            var ray = new Ray(position, rayDirection);
            if (Physics.Raycast(ray, out var hit, rayDirection.magnitude, _surfaceLayerMask))
            {
                var upDirection = -rayDirection.normalized;
                _rigidbody.MovePosition(hit.point + upDirection);
                _rigidbody.MoveRotation(Quaternion.FromToRotation(-transform.up, rayDirection) * transform.rotation);
            }

            if (Physics.Raycast(ray, out var hit1, rayDirection.magnitude, _appleLayerMask))
            {
                var upDirection = -rayDirection.normalized * 0.5f;
                MovingObjectOnAnApple.position = hit1.point + upDirection;
                MovingObjectOnAnApple.rotation = Quaternion.FromToRotation(-transform.up, rayDirection) * MovingObjectOnAnApple.rotation;
            }
            
            _positionsAndRotations.Add(new PositionAndRotationHolder(MovingObjectOnAnApple.position, Head.rotation));
            if (_positionsAndRotations.Count == 10)
            {
                _previousPositionsAndRotations = new List<PositionAndRotationHolder>(_positionsAndRotations);
                _positionsAndRotations.Clear();
            }
            BodySnake.UpdateGameNew(_previousPositionsAndRotations);
            
            var transform1 = transform;
            var forward = transform1.forward * LerpDirection.Direction.y;
            var right = transform1.right * LerpDirection.Direction.x;
            
            _rigidbody.velocity = (forward + right) * _speedMovement;
        }
    }
}
