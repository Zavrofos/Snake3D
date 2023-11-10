using UnityEngine;

namespace Prototype.Scripts
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private Transform _sphere;
        [SerializeField] private Transform _player;
        [SerializeField] private float _distance;

        private void LateUpdate()
        {
            var direction = (_player.position - _sphere.position).normalized;
            transform.position = _sphere.position + direction * _distance;
            transform.rotation = Quaternion.LookRotation(-direction, transform.up);
        }
    }
}

