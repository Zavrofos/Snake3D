using Prototype.Scripts.SpawnerFoodFolder;
using Prototype.Scripts.Touch;
using UnityEngine;

namespace Prototype.Scripts.Snake
{
    public class HeadSnake : MonoBehaviour
    {
        private readonly float _radiusFindFood = 3;

        public LerpDirection LerpDirection;
        [SerializeField] private LayerMask _foodLayerMask;
        [SerializeField] private BodySnake _bodySnake;
        [SerializeField] private SpawnerFood _spawnerFood;
        
        private void Update()
        {
            float angle = LerpDirection.Angle * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(new Vector3(0, angle,0));
            FindFood();
        }

        public void FindFood()
        {
            var food = Physics.OverlapSphere(transform.position, _radiusFindFood, _foodLayerMask);
            foreach (var part in food)
            {
                var partOfFood = part.GetComponent<Food>();
                var direction = (transform.position - part.transform.position).normalized;
                partOfFood.Move(direction);
                if (Vector3.Distance(transform.position, part.transform.position) < 0.5)
                {
                    Destroy(part.gameObject);
                    _bodySnake.isEatedFood = true;
                    _spawnerFood.SpawnFood();
                }
            }
        }
    }
}