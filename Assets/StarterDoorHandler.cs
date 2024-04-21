using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterDoorHandler : MonoBehaviour
{
    Collider collide;

    void Start()
    {
        collide = GetComponent<Collider>();
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            collide.isTrigger = false;
        }
    }
}
