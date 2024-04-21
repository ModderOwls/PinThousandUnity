using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallHandler : MonoBehaviour
{
    public Vector3 telePos;

    public Collider starterDoor;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.transform.position = telePos;
            coll.transform.eulerAngles = new Vector3(30, 0, 0);

            starterDoor.isTrigger = true;

            PinballController ball = coll.GetComponent<PinballController>();

            ball.rb.velocity = -transform.up*20;
            ball.cam.focusPlayer = false;
        }
    }
}
