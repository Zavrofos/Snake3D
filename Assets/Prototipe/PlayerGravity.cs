using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public Rigidbody planetCenter; 

    void FixedUpdate()
    {
        Vector3 directionToCenter = planetCenter.transform.position - transform.position;
        float distance = directionToCenter.magnitude;
        float forceMagnitude = planetCenter.mass * GetComponent<Rigidbody>().mass / (distance * distance);

        Vector3 force = directionToCenter.normalized * forceMagnitude;
        GetComponent<Rigidbody>().AddForce(force);
    }
}
