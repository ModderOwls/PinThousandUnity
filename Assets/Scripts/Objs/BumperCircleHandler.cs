using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperCircleHandler : MonoBehaviour
{
    public float bumperPower;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            Rigidbody ball = coll.GetComponent<Rigidbody>();

            ball.velocity += (ball.transform.position - transform.position).normalized * bumperPower;
        }
    }
}
