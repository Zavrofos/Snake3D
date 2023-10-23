using System.Collections;
using UnityEngine;

namespace Assets.Prototipe
{
    public class GravitationalAttractor : MonoBehaviour
    {
        public float GravitationalForce = 10.0f; 
        public GameObject Apple;

        void FixedUpdate()
        {
            if (Apple != null)
            {
                Vector3 directionToAttractor = Apple.transform.position - transform.position;
                float gravity = GravitationalForce / directionToAttractor.sqrMagnitude;
                GetComponent<Rigidbody>().AddForce(directionToAttractor.normalized * gravity);
            }
        }
    }
}