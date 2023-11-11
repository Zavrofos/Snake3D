using UnityEngine;

namespace Prototype.Scripts.SpawnerFoodFolder
{
    public class Food : MonoBehaviour
    {
        public float Speed;
        public void Move(Vector3 direction)
        {
            transform.Translate(direction * Speed * Time.deltaTime);
        }
    }
}
