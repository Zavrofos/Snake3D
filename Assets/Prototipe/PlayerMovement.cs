using System.Collections;
using UnityEngine;

namespace Assets.Prototipe
{
    public class PlayerMovement : MonoBehaviour
    {
        public Transform directionIndicator;
        public float MoveSpeed;
        private Vector3 directionToMove;

        private void Update()
        {
            if(Input.GetKey(KeyCode.W))
            {
                directionToMove.y = 1;
            }
            else if(Input.GetKey(KeyCode.S))
            {
                directionToMove.y = -1;
            }
            else
            {
                directionToMove.y = 0;
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                directionToMove.x = 1;
            }
            else if(Input.GetKey(KeyCode.A))
            {
                directionToMove.x = -1;
            }
            else
            {
                directionToMove.x = 0;
            }
        }


        private void FixedUpdate()
        {
            Vector3 direction = (directionIndicator.position - transform.position).normalized;

            if (direction != Vector3.zero)
            {
                transform.forward = direction;
            }

            transform.Translate(directionToMove * MoveSpeed * Time.deltaTime);
        }
    }
}