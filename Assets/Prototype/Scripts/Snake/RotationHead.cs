using Prototype.Scripts.Touch;
using UnityEngine;

namespace Prototype.Scripts.Snake
{
    public class RotationHead : MonoBehaviour
    {
        public LerpDirection LerpDirection;

        private void Update()
        {
            float angle = LerpDirection.Angle * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(new Vector3(0, angle,0));
        }
    }
}