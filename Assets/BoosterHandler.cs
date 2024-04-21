using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterHandler : MonoBehaviour
{
    public float boostPower;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            Rigidbody rb = coll.GetComponent<Rigidbody>();

            rb.velocity = transform.up * boostPower;
        }
    }
}
