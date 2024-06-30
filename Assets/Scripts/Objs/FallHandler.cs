using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallHandler : MonoBehaviour
{
    public Transform tele;

    public Collider starterDoor;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.transform.position = tele.position;
            coll.transform.eulerAngles = new Vector3(0, 0, 0);

            starterDoor.isTrigger = true;

            PinballController ball = coll.GetComponent<PinballController>();

            ball.rb.velocity = -transform.up*20;
            ball.lastPosition = coll.transform.position;
            ball.cam.focusPlayer = false;
        }
    }
}
