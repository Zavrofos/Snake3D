using UnityEngine;

namespace Prototype
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Transform _apple;
        [SerializeField] private Transform _sphere;
        [SerializeField] private LayerMask _appLayerMask;
        [SerializeField] private LayerMask _sphereLayerMask;
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rigidbody;

        private float _vertical;
        private float _horizontal;
        private Vector2 _direction;

        public Transform Player;
        public TouchInput Touch;
        
        private void Start()
        {
            _direction = transform.forward;
        }

        private void FixedUpdate()
        {
            var position = _rigidbody.position;
            var rayDirection = _sphere.position - position;

            var ray = new Ray(position, rayDirection);
            if (Physics.Raycast(ray, out var hit, rayDirection.magnitude, _sphereLayerMask))
            {
                var upDirection = -rayDirection.normalized;
                _rigidbody.MovePosition(hit.point + upDirection);
                _rigidbody.MoveRotation(Quaternion.FromToRotation(-transform.up, rayDirection) * transform.rotation);
            }

            if (Physics.Raycast(ray, out var hit1, rayDirection.magnitude, _appLayerMask))
            {
                var upDirection = -rayDirection.normalized;
                Player.position = hit1.point + upDirection;
                Player.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * Player.rotation;
            }


            var transform1 = transform;
            var forward = transform1.forward * _direction.y;
            Debug.Log(forward);
            var right = transform1.right * _direction.x;
            _rigidbody.velocity = (forward + right) * _speed;

            Debug.DrawRay(transform1.position, -transform1.up * 5, Color.green);
        }

        private void Update()
        {
            _vertical = Touch.Direction.y;
            _horizontal = Touch.Direction.x;

            if (_vertical == 0 && _horizontal == 0)
                return;

            var direction = new Vector2(_horizontal, _vertical).normalized;
            _direction = direction;
        }
    }
}
